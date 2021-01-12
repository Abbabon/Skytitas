using Entitas;
using Entitas.CodeGeneration.Attributes;
using Services.Interfaces;

namespace Components.MetaComponents
{
    [Meta, Unique]
    public class CollisionServiceComponent : IComponent
    {
        public ICollisionService Instance;
    }
}