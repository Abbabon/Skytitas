using ScriptableObjects;
using Services.Concrete;
using Types;
using UnityEngine;
using Views.Concrete;
using Views.UI;
using Zenject;

namespace Installers
{
    public class GameplayeServicesInstaller : MonoInstaller
    {
        [SerializeField] private AssetMapping _assetMapping;
        [SerializeField] private GameSettingsService _gameSettingsService;

        [SerializeField] private UiCanvasView _uiCanvasView;

        public override void InstallBindings()
        {
            BindMonoBehaviours();
            BindServices();
            BindFactories();
            BindPools();
        }
        
        private void BindMonoBehaviours()
        {
            Container.Bind<AssetMapping>().FromInstance(_assetMapping);
            Container.BindInterfacesTo<GameSettingsService>().FromInstance(_gameSettingsService);
            Container.Bind<UiCanvasView>().FromInstance(_uiCanvasView);
        }

        private void BindServices()
        {
            Container.BindInterfacesTo<UnityViewService>().AsSingle();
            Container.BindInterfacesTo<UnityInputService>().AsSingle();
            Container.BindInterfacesTo<UnityCollisionService>().AsSingle();
        }
        
        private void BindFactories()
        {
            Container.BindFactory<ShipView, ShipView.Factory>()
                .FromComponentInNewPrefab(_assetMapping.AssetLookup[AssetType.Spaceship].Prefab);
        }
        
        private void BindPools()
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