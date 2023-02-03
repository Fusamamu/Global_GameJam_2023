using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam
{
	public class DataManager : MonoBehaviour, IService
	{
		[field: SerializeField] public bool IsInit { get; private set; }

		public void Initialized()
		{
			if(IsInit) return;
			IsInit = true;
            
		}
		
	}
}
