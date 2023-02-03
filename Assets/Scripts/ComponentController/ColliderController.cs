using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam
{
    public class ColliderController : MonoBehaviour, ICollideAble
    {
        [field: SerializeField] public Collider  Collider  { get; private set; }
        [field: SerializeField] public Rigidbody Rigidbody { get; private set; }
        
        public ICollideAble EnableCollider()
        {
            Collider.enabled = true;
            return this;
        }

        public ICollideAble DisableCollider()
        {
            Collider.enabled = false;
            return this;
        }

        public ICollideAble EnableRigidBody()
        {
            Rigidbody.isKinematic = false;
            return this;
        }

        public ICollideAble DisableRigidBody()
        {
            Rigidbody.isKinematic = true;
            return this;
        }
    }
}
