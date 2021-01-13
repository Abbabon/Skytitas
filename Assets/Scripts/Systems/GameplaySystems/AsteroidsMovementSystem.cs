using Entitas;
using UnityEngine;

namespace Systems.GameplaySystems
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
                    _contexts.meta.gameSettings.instance.AsteroidsSpeed *
                    (_contexts.game.playerAcceleration.TurnedOn
                        ? _contexts.meta.gameSettings.instance.AccelerationSpeedFactor
                        : 1f) *
                    Time.deltaTime;
                
                var movementDelta = new Vector3(0, 0, zDelta);
                var newPosition = asteroidsEntity.position.Value + movementDelta;
                asteroidsEntity.ReplacePosition(newPosition);
            }
        }
    }
}