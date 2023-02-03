using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;

namespace GlobalGameJam
{
    public class CompleteUIElement : MonoBehaviour, IUIElement
    {
        [SerializeField] private TextMeshProUGUI CompleteText;
        
        [SerializeField] private MMF_Player OnShow;
        [SerializeField] private MMF_Player OnHide;

        public List<string> CompleteMessage = new List<string>();
        
        public void Initialized()
        {
            OnShow.Initialization();
            OnHide.Initialization();
        }

        public CompleteUIElement SetWellDone()
        {
            CompleteText.SetText("<bounce>WELL DONE!</bounce>");
            return this;
        }
        
        public CompleteUIElement Set()
        {
            CompleteText.SetText("<bounce>Caps off to you!</bounce>");
            return this;
        }
        
        public CompleteUIElement SetText(string _text)
        {
            CompleteText.SetText($"<bounce>{_text}</bounce>");
            return this;
        }
        
        public IUIElement Show()
        {
            OnShow.PlayFeedbacks();
            return this;
        }
        public IUIElement Hide()
        {
            OnHide.PlayFeedbacks();
            return this;
        }
    }
}
