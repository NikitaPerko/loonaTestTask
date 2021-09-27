using UnityEngine;

namespace LoonaTest.Game.GameActors.Characters
{
    public class PlayerMovement : IMovable
    {
        public Vector3 GetMovementDirection()
        {
            Input.GetAxisRaw("Horizontal");
            return new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        }
    }
}