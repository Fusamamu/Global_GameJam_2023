using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;

namespace GlobalGameJam
{
    public class TaskUIElement : MonoBehaviour, IUIElement
    {
        public TextMeshProUGUI TaskName;
        public TextMeshProUGUI Instruction;
        
        [SerializeField] private MMF_Player OnShow;
        [SerializeField] private MMF_Player OnHide;
        
        public void Initialized()
        {
            OnShow.Initialization();
            OnHide.Initialization();
        }

        public IUIElement Show()
        {
            OnShow.Direction = MMFeedbacks.Directions.TopToBottom;
            OnShow.PlayFeedbacks();
            return this;
        }
        public IUIElement Hide()
        {
            OnShow.Direction = MMFeedbacks.Directions.BottomToTop;
            OnShow.PlayFeedbacks();
            
            //OnHide.PlayFeedbacks();
            return this;
        }
    }
}
