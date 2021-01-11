using Entitas;
using UnityEngine;

namespace Systems
{
    public class PlayerMovementSystem : IExecuteSystem
    {
        private readonly Contexts _contexts;
        private IGroup<GameEntity> _playerEntities;

        public PlayerMovementSystem(Contexts contexts)
        {
            _contexts = contexts;
        }
        
        public void Execute()
        {
            var xDelta =
                _contexts.input.inputEntity.input.PlaneMovement.x * _contexts.meta.gameSettings.instance.PlayerSpeed * Time.deltaTime;
            
            var movementDelta = new Vector3(xDelta, 0, 0);
            
            var newPosition = _contexts.game.playerEntity.position.Position + movementDelta;
            
            var clampedNewPositionX = Mathf.Clamp(newPosition.x, 
                _contexts.meta.gameSettings.instance.PlayerMinimumX,
                _contexts.meta.gameSettings.instance.PlayerMaximumX);

            var clampedNewPosition = new Vector3(clampedNewPositionX, newPosition.y, newPosition.z);
            
            _contexts.game.playerEntity.ReplacePosition(clampedNewPosition);
        }
    }
}