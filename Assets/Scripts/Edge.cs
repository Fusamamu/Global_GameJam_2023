using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using Shapes;
using UnityEngine;

namespace GlobalGameJam
{
    public class Edge : MonoBehaviour
    {
        public Vector3 Start;
        public Vector3 End;

        [SerializeField] private Line       EdgeLine;
        [SerializeField] private MMF_Player OnActive;

        public void Initialized()
        {
            OnActive.Initialization();
        }

        public Edge SetEnd(Vector3 _pos)
        {
            End = _pos;
            return this;
        }

        public void PlayFeedback(string _feedback = "")
        {
            MMF_Property _property = OnActive.GetFeedbackOfType<MMF_Property>();
            
            _property.Target.Vector3RemapOne = End;
            
            OnActive.PlayFeedbacks();
        }
    }
}
