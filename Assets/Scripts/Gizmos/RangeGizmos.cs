using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shapes;
using MoreMountains.Feedbacks;

namespace GlobalGameJam
{
    public class RangeGizmos : MonoBehaviour, IGizmos
    {
        [field: SerializeField] public float Radius { get; set; }
        
        [field: SerializeField] public Disc RangeCircle { get; private set; }


        [SerializeField] private MMF_Player ShowFeedback;
        [SerializeField] private MMF_Player HideFeedback;
        
#if UNITY_EDITOR
        private void OnValidate()
        {
            if (RangeCircle)
                SetRadius(Radius);
        }
#endif
       
        public void Initialized()
        {
          
        }

        public IGizmos Show()
        {
            if (!ShowFeedback.IsPlaying)
            {
                MMF_Property _property = ShowFeedback.GetFeedbackOfType<MMF_Property>();
                _property.RemapLevelOne = Radius;
                ShowFeedback.PlayFeedbacks();
            }

            
            return this;
        }

        public IGizmos Hide()
        {
            if (!HideFeedback.IsPlaying)
            {
                MMF_Property _property = HideFeedback.GetFeedbackOfType<MMF_Property>();
                _property.RemapLevelZero = Radius;
                HideFeedback.PlayFeedbacks();
            }
            
            return this;
        }

        public RangeGizmos SetRadius(float _radius)
        {
            Radius = _radius;
            
            return this;
        }
    }
}
