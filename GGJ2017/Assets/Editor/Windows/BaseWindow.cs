using UnityEditor;
using UnityEngine;

namespace Assets.Editor.Windows
{
    public abstract class BaseWindow<T> : EditorWindow
        where T : BaseWindow<T>
    {
        protected abstract string Title { get; }

        public static T ShowSelf()
        {
            var window = GetWindow<T>();
            window.titleContent = new GUIContent(window.Title);
            window.Show();
            return window;
        }

        protected abstract void OnGUI();
    }
}
