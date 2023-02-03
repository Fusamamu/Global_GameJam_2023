using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;

namespace GlobalGameJam
{
    public class Enemy : MonoBehaviour, IEntity
    {
        public Transform EntityTransform { get; set; }
        
        [SerializeField] private MMF_Player OnEndMove;
        [SerializeField] private MMF_Player OnHit;
        [SerializeField] private MMF_Player OnHitObstacle;
        
        private void Start()
        {
            EntityTransform = transform;
        }
        
        public void PlayFeedback(string _feedback)
        {
            OnHit.PlayFeedbacks();
        }
    }
}
