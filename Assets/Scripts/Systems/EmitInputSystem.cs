using Entitas;
using Services.Interfaces;

namespace Systems
{
    public class EmitInputSystem : IInitializeSystem, IExecuteSystem
    {
        private Contexts _contexts;
        private IInputService _inputService;
        private InputEntity _inputEntity;

        public EmitInputSystem(Contexts contexts, IInputService inputService)
        {
            _contexts = contexts;
            _inputService = inputService;
        }
        
        public void Initialize()
        {
            _inputEntity = _contexts.input.inputEntity;
        }

        public void Execute()
        {
            _inputEntity.ReplaceInput(_inputService.HorizontalMovement, _inputService.ButtonAPressed);
        }
    }
}