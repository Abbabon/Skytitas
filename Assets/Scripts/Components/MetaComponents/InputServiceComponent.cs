using Entitas;
using Entitas.CodeGeneration.Attributes;
using Services.Interfaces;

namespace Components.MetaComponents
{
    [Meta, Unique]
    public class InputServiceComponent : IComponent
    {
        public IInputService instance;
    }
}