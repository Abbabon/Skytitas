using Services.Interfaces;
using UnityEngine;

namespace Services.Concrete
{
    public class UnityInputService : IInputService
    {
        private const string HORIZONTAL_AXIS_NAME = "Horizontal";
        private const string VERTICAL_AXIS_NAME = "Vertical";
        private static readonly KeyCode ACTION_1_KEYCODE = KeyCode.Space;

        public Vector2 HorizontalMovement => new Vector2(Input.GetAxis(HORIZONTAL_AXIS_NAME), Input.GetAxis(VERTICAL_AXIS_NAME));
        public bool ButtonAPressed => Input.GetKeyDown(ACTION_1_KEYCODE);
    }
}