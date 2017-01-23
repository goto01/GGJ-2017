using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Controllers.InputControllerSystem;
using UnityEngine;

namespace Assets.Scripts.Staff
{
    class ArrowComponent : MonoBehaviour
    {
        protected virtual void Update()
        {
            var dir = InputController.Instance.GetDir();
            dir.x *= -1;
            dir.y *= -1;

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
