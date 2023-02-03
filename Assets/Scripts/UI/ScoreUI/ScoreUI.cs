using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using MPUIKIT;
using TMPro;
using UnityEngine;

namespace GlobalGameJam
{
	public class ScoreUI : MonoBehaviour, IGameUI
	{
		[field: SerializeField] public bool IsInit { get; private set; }

		public TextMeshProUGUI ScoreCountText;
        
		[field: SerializeField] public Canvas UICanvas { get; private set; }

		[SerializeField] private MMF_Player ShowFeedback;
		[SerializeField] private MMF_Player HideFeedback;
        
		public void Initialized()
		{
			if(IsInit) return;
			IsInit = true;
		}

		public ScoreUI SetScore(int _score)
		{
			ScoreCountText.SetText(_score.ToString());
			return this;
		}

		public void Update()
		{
			if(!IsInit) return;
		}

		public void Show()
		{
			gameObject.SetActive(true);

			if(ShowFeedback == null) return;
			
			ShowFeedback.Direction = MMFeedbacks.Directions.TopToBottom;
			ShowFeedback.PlayFeedbacks();
		}
        
		public void Hide()
		{
			gameObject.SetActive(false);
			
			if(HideFeedback == null) return;
			
			HideFeedback.Direction = MMFeedbacks.Directions.TopToBottom;
			HideFeedback.PlayFeedbacks();
		}
	}
}
