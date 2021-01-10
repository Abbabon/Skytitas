using Systems.RegistrationSystems;
using ScriptableObjects;
using Services.Concrete;
using UnityEngine;

namespace Bootstrap
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private AssetMapping _assetMapping;
        
        private Entitas.Systems _systems;
    
        private void Start()
        {
            var contexts = Contexts.sharedInstance;
            var services = new GameServices(new UnityInputService(), new UnityViewService(_assetMapping));
        
            _systems = CreateSystems(contexts, services);
            _systems.Initialize();
        }

        private Entitas.Systems CreateSystems(Contexts contexts, GameServices gameServices)
        {
            return new Feature("Game")
                .Add(new RegisterInputServiceSystem(contexts, gameServices.InputService))
                .Add(new RegisterViewServiceSystem(contexts, gameServices.ViewService));
        }
    }
}
