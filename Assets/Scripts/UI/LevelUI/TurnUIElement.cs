using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;

namespace GlobalGameJam
{
    public class TurnUIElement : MonoBehaviour, IUIElement
    {
        public TextMeshProUGUI TurnMessage;

        public MMF_Player OnShowFeedback;
        public MMF_Player OnHideFeedback;
        
        public void Initialized()
        {
            OnShowFeedback.Initialization();
            OnHideFeedback.Initialization();
        }
        
        public IUIElement Show()
        {
            OnHideFeedback.Direction = MMFeedbacks.Directions.BottomToTop;
            OnHideFeedback.PlayFeedbacks();
            
            OnShowFeedback.PlayFeedbacks();
            return this;
        }
        
        public IUIElement Hide()
        {
            OnHideFeedback.Direction = MMFeedbacks.Directions.TopToBottom;
            OnHideFeedback.PlayFeedbacks();
            return this;
        }
    }
}
