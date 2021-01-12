using ScriptableObjects;
using Services.Concrete;
using Types;
using UnityEngine;
using Views.Concrete;
using Zenject;

namespace Installers
{
    public class GameplayeServicesInstaller : MonoInstaller
    {
        [SerializeField] private AssetMapping _assetMapping;
        [SerializeField] private GameSettingsService _gameSettingsService;
        
        public override void InstallBindings()
        {
            BindMonobehaviourServices();
            InitializeServices();
            InitializePools();
        }

        private void BindMonobehaviourServices()
        {
            Container.Bind<AssetMapping>().FromInstance(_assetMapping);
            Container.BindInterfacesTo<GameSettingsService>().FromInstance(_gameSettingsService);
        }

        private void InitializeServices()
        {
            Container.BindInterfacesTo<UnityViewService>().AsSingle();
            Container.BindInterfacesTo<UnityInputService>().AsSingle();
        }
        
        private void InitializePools()
        {
            if (_assetMapping.AssetLookup.TryGetValue(AssetType.Asteroid, out var assetConfiguraiton))
            {
                Container.BindMemoryPool<AsteroidView, AsteroidView.Pool>()
                    .WithInitialSize(10)
                    .FromComponentInNewPrefab(assetConfiguraiton.Prefab)
                    .UnderTransformGroup("Asteroids");
            }
        }
    }
}