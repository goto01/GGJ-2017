using UnityEngine;

namespace Assets.Scripts.Staff.Helpers
{
    public static class Vector2Helper
    {
        public static Vector2 ClampVector(Vector2 vector2, float minValue, float maxValue)
        {
            vector2[0] = Mathf.Clamp(vector2[0], minValue, maxValue);
            vector2[1] = Mathf.Clamp(vector2[1], minValue, maxValue);
            return vector2;
        }

        public static Vector3 ClampVector(Vector3 vector3, float minValue, float maxValue)
        {
            var z = vector3.z;
            vector3 = ClampVector((Vector2) vector3, minValue, maxValue);
            vector3.z = z;
            return vector3;
        }
    }
}
