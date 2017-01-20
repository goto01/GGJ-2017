using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using Assets.Scripts.Staff.Windows;
#endif

namespace Assets.Scripts.Components.StageComponents.ReactableStageComponents.Reactions
{
    abstract class BaseReaction : ScriptableObject
    {
        [SerializeField] private string _reactionName;

        public string ReactionName { get { return _reactionName; } }

        public abstract void HandleReactionHappining(GameObject gameObject);

        public abstract void HandleReactionSkipped(GameObject gameObject);

#if UNITY_EDITOR

        [MenuItem("Assets/Create/Reaction")]
        public static void CreateReaction()
        {
            ScriptableObjectCreatorWindow.ShowSelf().InitBySubClasses<BaseReaction>();
        }
#endif
    }
}