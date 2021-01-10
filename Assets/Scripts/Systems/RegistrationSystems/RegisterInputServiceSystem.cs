using Entitas;
using Services.Interfaces;

namespace Systems.RegistrationSystems
{
    public class RegisterInputServiceSystem : IInitializeSystem
    {
        private readonly MetaContext _metaContext;
        private readonly IInputService _inputService;

        public RegisterInputServiceSystem(Contexts contexts, IInputService inputService)
        {
            _metaContext = contexts.meta;
            _inputService = inputService;
        }
        
        public void Initialize()
        {
            _metaContext.ReplaceInputService(_inputService);
        }
    }
}