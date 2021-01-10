using Entitas;
using Entitas.CodeGeneration.Attributes;
using Services.Interfaces;

namespace Components.MetaComponents
{
    [Meta, Unique]
    public class ViewServiceComponent : IComponent
    {
        public IViewService instance;
    }
}