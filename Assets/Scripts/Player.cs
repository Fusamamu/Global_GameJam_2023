using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;

namespace GlobalGameJam
{
    public class Player : MonoBehaviour, IPlayer, IEntity
    {
        [field: SerializeField] public bool UseAbility { get; private set; }
        
        [field: SerializeField] public Transform EntityTransform { get; set; }

        [SerializeField] private float WaitInterval = 0.2f;
        
        [SerializeField] private List<Ability> Abilities = new List<Ability>();

        [SerializeField] private MMF_Player OnEndMove;
        [SerializeField] private MMF_Player OnHit;
        [SerializeField] private MMF_Player OnHitObstacle;

        private IEnumerator Start()
        {
            if(!UseAbility)
                yield break;
            
            yield return new WaitForSeconds(4);

            EntityTransform = transform;
            
            StartCoroutine(PerformAbilities());
        }

        public IEnumerator PerformAbilities()
        {
            foreach (var _ability in Abilities)
            {
                _ability.Init();

                yield return new WaitForSeconds(WaitInterval);
                yield return _ability.Perform(this);
            }

            yield return null;
        }

        public void PlayFeedback(string _feedback)
        {
            OnHitObstacle.PlayFeedbacks();
        }
    }
}
