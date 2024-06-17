using UnityEngine;

namespace Game.Scripts.Input_Module
{
    public interface IPlayerInput
    {
        Vector2 MoveAxis { get; }
    }
}