using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam
{
    public interface IEntity
    {
        public Transform EntityTransform { get; set; }

        public void PlayFeedback(string _feedback);
    }
}
