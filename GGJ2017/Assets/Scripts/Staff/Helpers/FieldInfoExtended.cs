using System;
using System.Linq;
using System.Reflection;

namespace Assets.Scripts.Staff.Helpers
{
    public static class FieldInfoExtended
    {
        public static T GetAttribute<T>(this FieldInfo fieldInfo) where T : Attribute
        {
            return fieldInfo.GetCustomAttributes(true).FirstOrDefault(x => x is T) as T;
        }
    }
}
