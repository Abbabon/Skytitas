using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Components.GameComponents
{
    [Game, Event(EventTarget.Self)]
    public class PlayerComponent : IComponent
    {
        
    }
}