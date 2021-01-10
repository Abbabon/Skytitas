using Services.Interfaces;
using UnityEngine;

namespace Services.Concrete
{
    public class UnityInputService : IInputService
    {
        private const string HORIZONTAL_AXIS_NAME = "Horizontal";
        private const string VERTICAL_AXIS_NAME = "Vertical";
        private static readonly string ACTION_1_KEYNAME = KeyCode.Space.ToString();

        public Vector2 HorizontalMovement => new Vector2(Input.GetAxis(HORIZONTAL_AXIS_NAME), Input.GetAxis(VERTICAL_AXIS_NAME));
        public bool ButtonAPressed => Input.GetButtonDown(ACTION_1_KEYNAME);
    }
}