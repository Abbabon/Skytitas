using UnityEngine;

namespace Services.Interfaces
{
    public interface IInputService
    {
        Vector2 HorizontalMovement { get; }
        bool ButtonAPressed { get; }
    }
}