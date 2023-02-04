using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;

namespace GlobalGameJam
{
	public class SeedSelectionUI : MonoBehaviour, IGameUI
	{
		public bool IsShow;
		
		[field: SerializeField] public bool IsInit { get; private set; }
        
		[field: SerializeField] public Canvas UICanvas { get; private set; }

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
			if(ShowFeedback == null) return;
			
			ShowFeedback.Direction = MMFeedbacks.Directions.TopToBottom;
			ShowFeedback.PlayFeedbacks();

			IsShow = true;
		}
        
		public void Hide()
		{
			if(HideFeedback == null) return;
			
			HideFeedback.Direction = MMFeedbacks.Directions.TopToBottom;
			HideFeedback.PlayFeedbacks();

			IsShow = false;
		}
	}
}
