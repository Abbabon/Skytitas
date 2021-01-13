using Entitas;
using Services.Interfaces;

namespace Systems.GameplaySystems
{
    public class PlayerCollisionSystem : IInitializeSystem
    {
        private readonly Contexts _contexts;
        private readonly ICollisionService _collisionService;

        public PlayerCollisionSystem(Contexts contexts, ICollisionService collisionService)
        {
            _contexts = contexts;
            _collisionService = collisionService;
        }
        
        public void Initialize()
        {
            _collisionService.RegisterPlayerCollisionListener(OnPlayerCollision);
        }

        private void OnPlayerCollision(GameEntity entity)
        {
            if (_contexts.game.hasScore)
            {
                _contexts.game.ReplaceScore(0);
                entity.isDestroyed = true;
            }
        }
    }
}