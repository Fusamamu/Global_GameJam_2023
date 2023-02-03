using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam
{
    [CreateAssetMenu(fileName = "NewAbility", menuName = "ScriptableObjects/Ability", order = 1)]
    public abstract class Ability : ScriptableObject
    {
        public abstract void Init();
        public abstract IEnumerator Perform(IEntity _entity, Action _onCompleted = null);
        public abstract void StopPerform();
    }
}
