using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;
using MPUIKIT;
using TMPro;

namespace GlobalGameJam
{
	public class LevelUI : MonoBehaviour, IGameUI
	{
		[field: SerializeField] public bool IsInit { get; private set; }

		public GameObject PressSpaceBarUI;

		public TextMeshProUGUI LevelText;
		public TextMeshProUGUI DetailText;
        
		[field: SerializeField] public Canvas UICanvas { get; private set; }


		public TurnUIElement TurnUIElement;

		[SerializeField] private MMF_Player ShowFeedback;
		[SerializeField] private MMF_Player HideFeedback;


		public void Initialized()
		{
			if(IsInit) return;
			IsInit = true;
			
		}

		public LevelUI SetLevelText(int _level)
		{
			LevelText.SetText($"<bounce>LEVEL {_level}</bounce>");
			return this;
		}

		public LevelUI SetDetailText(string _detail)
		{
			DetailText.SetText($"<shake>{_detail}</shake>");
			return this;
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
			
			PressSpaceBarUI.SetActive(true);
		}
        
		public void Hide()
		{
			if(ShowFeedback == null) return;
			ShowFeedback.Direction = MMFeedbacks.Directions.BottomToTop;
			ShowFeedback.PlayFeedbacks();
			
			PressSpaceBarUI.SetActive(false);
		}
	}
}
