using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Staff
{
    class PositionDependent : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        protected virtual void Update()
        {
            var position = _target.position;
            position.z = transform.position.z;
            transform.position = position;
        }
    }
}
