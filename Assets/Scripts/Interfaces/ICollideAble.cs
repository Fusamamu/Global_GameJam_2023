using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam
{
    public interface ICollideAble
    {
        public ICollideAble EnableCollider();
        public ICollideAble DisableCollider();
        public ICollideAble EnableRigidBody();
        public ICollideAble DisableRigidBody();

    }
}
