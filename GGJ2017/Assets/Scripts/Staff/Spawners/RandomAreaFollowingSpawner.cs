using UnityEngine;

namespace Assets.Scripts.Staff.Spawners
{
    class RandomAreaFollowingSpawner : FollowingSpawner
    {
        [SerializeField] private float _horizontal;
        [SerializeField] private float _vertical;
        [SerializeField] private float _verticalOffset;

        //protected override Vector2 Position
        //{
        //    get { return base.Position + new Vector2(Random.Range(-_horizontal, _horizontal), _verticalOffset + Random.Range(-_vertical, _vertical)); }
        //}
    }
}
