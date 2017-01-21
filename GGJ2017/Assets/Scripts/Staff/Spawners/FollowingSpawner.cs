using System.Collections;
using Assets.Scripts.Staff.Pool;
using UnityEngine;

namespace Assets.Scripts.Staff.Spawners
{
    class FollowingSpawner : BaseSpawner
    {
        [SerializeField] private Transform _transform;

        protected override Vector2 Position
        {
            get
            {
                var position = _transform.position;
                position.z = transform.position.z;
                return position;
            }
        }
    }
}
