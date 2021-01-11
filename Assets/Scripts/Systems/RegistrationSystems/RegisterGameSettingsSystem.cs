using Entitas;
using ScriptableObjects;
using Services.Concrete;
using Services.Interfaces;

namespace Systems.RegistrationSystems
{
    public class RegisterGameSettingsSystem : IInitializeSystem
    {
        private readonly MetaContext _metaContext;
        private readonly IGameSettingsService _gameSettingsService;

        public RegisterGameSettingsSystem(Contexts contexts, IGameSettingsService gameSettingsService)
        {
            _metaContext = contexts.meta;
            _gameSettingsService = gameSettingsService;
        }
        
        public void Initialize()
        {
            _metaContext.ReplaceGameSettings(_gameSettingsService);
        }
    }
}