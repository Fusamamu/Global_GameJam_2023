using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using MPUIKIT;
using UnityEngine;
using UnityEngine.UI;

namespace GlobalGameJam
{
	public class ExtraInfoUI : MonoBehaviour, IGameUI
	{
		[field: SerializeField] public bool IsInit { get; private set; }
        
		[field: SerializeField] public Canvas UICanvas { get; private set; }

		[SerializeField] private MPImage TransitionImage;

		// [SerializeField] private MMF_Player ShowFeedback;
		// [SerializeField] private MMF_Player HideFeedback;

		public bool IsShow;

		public bool IsTempHide;
        
		public void Initialized()
		{
			if(IsInit) return;
			IsInit = true;
			
			//ShowFeedback.Initialization();
			UICanvas.enabled = false;
		}

		public void Update()
		{
			if(!IsInit) return;
		}

		public void TempHide()
		{
			IsTempHide = true;
			Hide();
		}

		public void TryShow()
		{
			if (IsTempHide && IsShow)
			{
				Show();
				IsTempHide = false;
			}
		}

		public void Show()
		{
			IsShow = true;
			
			UICanvas.enabled = true;
			// if(ShowFeedback == null) return;
			// ShowFeedback.Direction = MMFeedbacks.Directions.TopToBottom;
			// ShowFeedback.PlayFeedbacks();
		}
        
		public void Hide()
		{
			if(!IsTempHide)
				IsShow = false;
			
			UICanvas.enabled = false;
			// if(ShowFeedback == null) return;
			// ShowFeedback.Direction = MMFeedbacks.Directions.BottomToTop;
			// ShowFeedback.PlayFeedbacks();
		}
	}
}
