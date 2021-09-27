using UnityEngine;

namespace LoonaTest.Game
{
    public static class VectorUtils
    {
        public static Vector2 GetXZ(this Vector3 vector)
        {
            return new Vector2(vector.x, vector.z);
        }

        public static Vector3 GetXYZWithZeroY(this Vector2 vector2)
        {
            return new Vector3(vector2.x, 0, vector2.y);
        }
    }
}