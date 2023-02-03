using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using MPUIKIT;
using UnityEngine;

namespace GlobalGameJam
{
    public class DiceUI : MonoBehaviour, IGameUI
    {
        [field: SerializeField] public bool IsInit { get; private set; }
        
        [field: SerializeField] public Canvas UICanvas { get; private set; }

        [SerializeField] private MPImage TransitionImage;

        [SerializeField] private MMF_Player ShowFeedback;
        [SerializeField] private MMF_Player HideFeedback;
        
        public void Initialized()
        {
            if(IsInit) return;
            IsInit = true;
        }

        public void Update()
        {
            if(!IsInit) return;
        }

        public void Show()
        {
            ShowFeedback.Direction = MMFeedbacks.Directions.TopToBottom;
            ShowFeedback.PlayFeedbacks();
        }
        
        public void Hide()
        {
            ShowFeedback.Direction = MMFeedbacks.Directions.BottomToTop;
            ShowFeedback.PlayFeedbacks();
        }
    }
}
