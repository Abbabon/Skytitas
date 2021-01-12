using Entitas;
using Services.Interfaces;

namespace Systems.RegistrationSystems
{
    public class RegisterCollisionServiceSystem : IInitializeSystem
    {
        private readonly MetaContext _metaContext;
        private readonly ICollisionService _collisionService;

        public RegisterCollisionServiceSystem(Contexts contexts, ICollisionService collisionService)
        {
            _metaContext = contexts.meta;
            _collisionService = collisionService;
        }
        
        public void Initialize()
        {
            _metaContext.ReplaceCollisionService(_collisionService);
        }
    }
}