using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam
{
	public class DataManager : MonoBehaviour, IService
	{
		[field: SerializeField] public bool IsInit { get; private set; }

		public int Score;

		[SerializeField] private ScoreUI ScoreUI;

		public void Initialized()
		{
			if(IsInit) return;
			IsInit = true;

			//ScoreUI = ServiceLocator.Instance.Get<UIManager>().GetUI<ScoreUI>();
		}

		public void IncreaseScore(int _value)
		{
			Score += _value;
			
			ScoreUI.ScoreCountText.SetText(Score.ToString());
		}
		
		public void DecreaseScore(int _value)
		{
			Score -= _value;
			
			ScoreUI.ScoreCountText.SetText(Score.ToString());
		}
		
	}
}
