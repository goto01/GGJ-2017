using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Editor.Helpers
{
    public static class ReflectionHelper
    {
        public static IEnumerable<Type> GetSubClasses<T>() where T : ScriptableObject
        {
            return typeof (T).Assembly.GetTypes().Where(type => !type.IsAbstract &&
                                                         type.IsSubclassOf(typeof (T)) &&
                                                         type.IsClass);
        }

        public static IEnumerable<Type> GetClasses<T>() where T : ScriptableObject
        {
            return
                typeof (T).Assembly.GetTypes()
                    .Where(type => !type.IsAbstract && type.IsClass && type == typeof(T));
        }
    }
}
