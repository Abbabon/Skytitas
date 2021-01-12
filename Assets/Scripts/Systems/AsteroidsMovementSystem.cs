using Entitas;
using UnityEngine;

namespace Systems
{
    public class AsteroidsMovementSystem : IExecuteSystem
    {
        private readonly Contexts _contexts;
        private IGroup<GameEntity> _asteroidsEntities;

        public AsteroidsMovementSystem(Contexts contexts)
        {
            _contexts = contexts;
            _asteroidsEntities = _contexts.game.GetGroup(GameMatcher.Asteroid);
        }
        
        public void Execute()
        {
            foreach (var asteroidsEntity in _asteroidsEntities)
            {
                var zDelta =
                    _contexts.meta.gameSettings.instance.AsteroidsSpeed * Time.deltaTime;
                var movementDelta = new Vector3(0, 0, zDelta);
                var newPosition = asteroidsEntity.position.Value + movementDelta;
                asteroidsEntity.ReplacePosition(newPosition);
            }
        }
    }
}