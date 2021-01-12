using ScriptableObjects;
using Services.Concrete;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameplayeServicesInstaller : MonoInstaller
    {
        [SerializeField] private AssetMapping _assetMapping;
        [SerializeField] private GameSettingsService _gameSettingsService;
        
        public override void InstallBindings()
        {
            Container.Bind<AssetMapping>().FromInstance(_assetMapping);
            Container.BindInterfacesTo<GameSettingsService>().FromInstance(_gameSettingsService);

            InitializeServices();
        }

        private void InitializeServices()
        {
            Container.BindInterfacesTo<UnityViewService>().FromInstance(new UnityViewService(_assetMapping));
            Container.BindInterfacesTo<UnityInputService>().FromInstance(new UnityInputService());
        }
    }
}