using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Components.GameComponents
{
    [Game, Unique, Event(EventTarget.Self)]
    public class ScoreComponent : IComponent
    {
        public int Value;
    }
}