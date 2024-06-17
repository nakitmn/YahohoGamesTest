using UnityEngine;

namespace Game.Scripts.Input_Module
{
    public sealed class JoystickPlayerInput : IPlayerInput
    {
        public Vector2 MoveAxis => _joystick.Direction;
        
        private readonly Joystick _joystick;

        public JoystickPlayerInput(Joystick joystick)
        {
            _joystick = joystick;
        }
    }
}