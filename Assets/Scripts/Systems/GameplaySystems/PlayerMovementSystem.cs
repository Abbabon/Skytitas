using Entitas;
using UnityEngine;

namespace Systems.GameplaySystems
{
    public class PlayerMovementSystem : IExecuteSystem
    {
        private readonly Contexts _contexts;

        public PlayerMovementSystem(Contexts contexts)
        {
            _contexts = contexts;
        }
        
        public void Execute()
        {
            UpdatePlayerAcceleration();
            UpdatePlayerPosition();
        }
        
        private void UpdatePlayerAcceleration()
        {
            _contexts.game.playerAccelerationEntity.ReplacePlayerAcceleration(_contexts.input.inputEntity.input.ButtonAPressed);
        }
        
        private void UpdatePlayerPosition()
        {
            var xDelta =
                _contexts.input.inputEntity.input.PlaneMovement.x * _contexts.meta.gameSettings.instance.PlayerSpeed *
                (_contexts.game.playerAcceleration.TurnedOn ? _contexts.meta.gameSettings.instance.AccelerationSpeedFactor : 1f) *
                Time.deltaTime;

            var movementDelta = new Vector3(xDelta, 0, 0);

            var newPosition = _contexts.game.playerEntity.position.Value + movementDelta;

            var clampedNewPositionX = Mathf.Clamp(newPosition.x,
                _contexts.meta.gameSettings.instance.PlayerMinimumX,
                _contexts.meta.gameSettings.instance.PlayerMaximumX);

            var clampedNewPosition = new Vector3(clampedNewPositionX, newPosition.y, newPosition.z);

            _contexts.game.playerEntity.ReplacePosition(clampedNewPosition);
        }
    }
}