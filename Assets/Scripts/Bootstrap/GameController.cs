using Systems;
using Systems.InitializationSystems;
using Systems.RegistrationSystems;
using Services.Interfaces;
using UnityEngine;
using Zenject;

namespace Bootstrap
{
    public class GameController : MonoBehaviour
    {
        private IGameSettingsService _gameSettingsService;
        private IInputService _inputService;
        private IViewService _viewService;
        
        private Entitas.Systems _systems;

        [Inject]
        private void Initialize(
            IGameSettingsService gameSettingsService, 
            IInputService inputService, 
            IViewService viewService)
        {
            _gameSettingsService = gameSettingsService;
            _inputService = inputService;
            _viewService = viewService;
        }
        
        private void Start()
        {
            var contexts = Contexts.sharedInstance;
            
            _systems = CreateSystems(contexts);
            _systems.Initialize();
        }
        
        private void Update()
        {
            _systems.Execute();
        }

        private Entitas.Systems CreateSystems(Contexts contexts)
        {
            return new Feature("Game")
                //Register services:
                .Add(new RegisterInputServiceSystem(contexts, _inputService))
                .Add(new RegisterViewServiceSystem(contexts, _viewService))
                .Add(new RegisterGameSettingsSystem(contexts, _gameSettingsService))

                //Base Systems:
                .Add(new MultiDestroySystem(contexts))
                .Add(new LoadAssetSystem(contexts))
                .Add(new EmitInputSystem(contexts))
                .Add(new UpdateTimersSystem(contexts))

                //EventSystems:
                .Add(new PositionEventSystem(contexts))

                //Initialize Gameeplay Systems
                .Add(new PlayerMovementSystem(contexts))
                .Add(new AsteroidsMovementSystem(contexts))
                .Add(new AsteroidGenerationSystem(contexts, _gameSettingsService))
                .Add(new AsteroidsDestructionSystem(contexts, _gameSettingsService))

                //Initialize Core Entities
                .Add(new InitializePlayerSystem(contexts));
        }
    }
}
