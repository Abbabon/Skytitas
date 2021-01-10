using Entitas;

namespace Systems
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
            var moveRight = _contexts.input.inputEntity.input.HorizontalMovement.x > 0f;
            var moveLeft = _contexts.input.inputEntity.input.HorizontalMovement.x < 0f;

        }
    }
}