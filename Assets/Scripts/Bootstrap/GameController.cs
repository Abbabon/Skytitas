using Systems;
using Systems.InitializationSystems;
using Systems.RegistrationSystems;
using ScriptableObjects;
using Services.Concrete;
using UnityEngine;

namespace Bootstrap
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private AssetMapping _assetMapping;
        [SerializeField] private GameSettingsService _gameSettingsService;
        
        private Entitas.Systems _systems;
    
        private void Start()
        {
            var contexts = Contexts.sharedInstance;
            var services = new GameServices(new UnityInputService(), new UnityViewService(_assetMapping));
            
            _systems = CreateSystems(contexts, services);
            _systems.Initialize();
        }
        
        private void Update()
        {
            _systems.Execute();
        }

        private Entitas.Systems CreateSystems(Contexts contexts, GameServices gameServices)
        {
            return new Feature("Game")
                //Register services:
                .Add(new RegisterInputServiceSystem(contexts, gameServices.InputService))
                .Add(new RegisterViewServiceSystem(contexts, gameServices.ViewService))
                .Add(new RegisterGameSettingsSystem(contexts, _gameSettingsService))

                //Base Systems:
                .Add(new LoadAssetSystem(contexts))
                .Add(new EmitInputSystem(contexts))

                //EventSystems:
                .Add(new PositionEventSystem(contexts))

                //Initialize Gameplay Systems
                .Add(new PlayerMovementSystem(contexts))

                //Initialize Core Entities
                .Add(new InitializePlayerSystem(contexts));
        }
    }
}
