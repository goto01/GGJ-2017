using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Staff.Helpers
{
    public static class GameObjectExtended
    {
        public static void SetZToLocalPosition(this Transform transform, float z)
        {
            var position = transform.localPosition;
            position.z = z;
            transform.localPosition = position;
        }

        public static void SetZToPosition(this Transform transform, float z)
        {
            var position = transform.position;
            position.z = z;
            transform.position = position;
        }

        public static Vector2 GetXY(this Transform transform)
        {
            return new Vector2(transform.position.x, transform.position.y);
        }

        public static void SetXYPosition(this Transform transform, Vector3 position)
        {
            position.z = transform.position.z;
            transform.position = position;
        }

        public static void SetXYPosition(this Transform transform, Vector2 position)
        {
            transform.position = new Vector3(position.x, position.y, transform.position.z);
        }

        public static void SetYLocalPosition(this Transform transform, float y)
        {
            var position = transform.localPosition;
            position.y = y;
            transform.localPosition = position;
        }

        public static void SetYPosition(this Transform transform, float y)
        {
            var position = transform.position;
            position.y = y;
            transform.position = position;
        }

        public static void SetXPosition(this Transform transform, float x)
        {
            var position = transform.position;
            position.x = x;
            transform.position = position;
        }

        public static void SetXLocalPosition(this Transform transform, float x)
        {
            var position = transform.localPosition;
            position.x = x;
            transform.localPosition = position;
        }

        public static void SetXYLocalPosition(this Transform transform, Vector3 localPosition)
        {
            localPosition.z = transform.localPosition.z;
            transform.localPosition = localPosition;
        }

        public static void AddLocalX(this Transform transform, float offset)
        {
            var position = transform.localPosition;
            position.x += offset;
            transform.localPosition = position;
        }

        public static void AddLocalY(this Transform transform, float offset)
        {
            var position = transform.localPosition;
            position.y += offset;
            transform.localPosition = position;
        }

        public static void AddLocalZ(this Transform transform, float offset)
        {
            var position = transform.localPosition;
            position.z += offset;
            transform.localPosition = position;
        }

        public static void AddLocalXY(this Transform transform, Vector2 offset)
        {
            transform.localPosition += (Vector3)offset;
        }

        public static void AddXY(this Transform transform, Vector2 offset)
        {
            transform.position += (Vector3) offset;
        }

        public static Vector3 GetXY(Vector3 vector3, Vector2 vector2)
        {
            vector3.x = vector2.x;
            vector3.y = vector2.y;
            return vector3;
        }

        public static void SetLocalScaleX(this Transform transform, float x)
        {
            var scale = transform.localScale;
            scale.x = x;
            transform.localScale = scale;
        }

        public static void SetLocalScaleY(this Transform transform, float y)
        {
            var scale = transform.localScale;
            scale.y = y;
            transform.localScale = scale;
        }

        public static void SetLocalScaleZ(this Transform transform, float z)
        {
            var scale = transform.localScale;
            scale.z = z;
            transform.localScale = scale;
        }

        public static List<GameObject> GetChildrenGameObjectsByTag(GameObject @object, params string[] tags)
        {
            var childrenCount = @object.transform.childCount;
            var requiredChildren = new List<GameObject>();
            for (var index = 0; index < childrenCount; index++)
            {
                var child = @object.transform.GetChild(index);
                if (tags.Any(tag=>child.CompareTag(tag)))
                    requiredChildren.Add(child.gameObject);
            }
            return requiredChildren;
        }
        
        public static T GetOrAddIfNotExistComponent<T>(this MonoBehaviour behaviour) where T:Component
        {
            var component = behaviour.GetComponent<T>();
            if (!component) component = behaviour.gameObject.AddComponent<T>();
            return component;
        }

        public static Component GetOrAddIfNotExistComponent(this MonoBehaviour behaviour, Type type)
        {
            if (!type.IsSubclassOf(typeof (Component))) throw new Exception("Type of component is't subclass of MonoBehhaviour");
            var component = behaviour.GetComponent(type);
            if (!component) component = behaviour.gameObject.AddComponent(type);
            return component;
        }
    }
}