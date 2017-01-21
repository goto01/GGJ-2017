using UnityEngine;

namespace Assets.Scripts.Staff.Spawners
{
    class RandomAreaFollowingSpawner : FollowingSpawner
    {
        [SerializeField] private float _horizontal;
        [SerializeField] private float _vertical;
        [SerializeField] private float _verticalOffset;

        protected override Vector2 Position
        {
            get { return GetPosition(base.Position); }
        }

        protected Vector2 GetPosition(Vector2 position)
        {
            return position + new Vector2(Random.Range(-_horizontal, _horizontal), _verticalOffset + Random.Range(-_vertical, _vertical));
        }

        public override void Spawn(Vector3 position)
        {
            var @object = _pool.PopObject();
            position.z = @object.transform.position.z;
            @object.transform.position = GetPosition(position);
        }

    }
}
