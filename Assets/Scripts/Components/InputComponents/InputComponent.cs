using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Components.InputComponents
{
    [Input, Unique]
    public class InputComponent : IComponent
    {
        public Vector2 PlaneMovement;
        public bool ButtonAPressed;
    }
}