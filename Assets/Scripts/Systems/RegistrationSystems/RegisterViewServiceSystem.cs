using Entitas;
using Services.Interfaces;

namespace Systems.RegistrationSystems
{
    public class RegisterViewServiceSystem : IInitializeSystem
    {
        private readonly IViewService _viewService;
        private readonly MetaContext _metaContext;
        
        public RegisterViewServiceSystem(Contexts contexts, IViewService viewService)
        {
            _metaContext = contexts.meta;
            _viewService = viewService;
        }
        
        public void Initialize()
        {
            _metaContext.ReplaceViewService(_viewService);
        }
    }
}