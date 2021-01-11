using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Components.GameComponents
{
    [Game, Event(EventTarget.Self)]
    public class PositionComponent : IComponent
    {
        public Vector3 Value;
    }
}