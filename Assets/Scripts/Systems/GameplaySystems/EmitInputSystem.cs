using Entitas;

namespace Systems.GameplaySystems
{
    public class EmitInputSystem : IInitializeSystem, IExecuteSystem
    {
        private Contexts _contexts;
        private InputEntity _inputEntity;

        public EmitInputSystem(Contexts contexts)
        {
            _contexts = contexts;
        }
        
        public void Initialize()
        {
            _inputEntity = _contexts.input.CreateEntity();
        }

        public void Execute()
        {
            _inputEntity.ReplaceInput(_contexts.meta.inputService.instance.HorizontalMovement,
                _contexts.meta.inputService.instance.ButtonAPressed);
        }
    }
}