using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam
{
	public class FeedbackManager : MonoBehaviour, IService
	{
		[field: SerializeField] public bool IsInit { get; private set; }

		public GameObject ScoreTextPrefab;

		public void Initialized()
		{
			if(IsInit) return;
			IsInit = true;
		}
		
	}
}
