using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam
{
	public class AudioManager : MonoBehaviour, IService
	{
		[field: SerializeField] public bool IsInit { get; private set; }

		public AudioSource Bgm;

		public AudioSource PlacingSound;
		public AudioSource GrowingNodeSound;
		public AudioSource GrowingTreeSound;

		public AudioSource OnPlantConnectedSound;

		public AudioSource OnDiceRolledSound;
		public AudioSource OnDiceSnapToPosSound;
		public AudioSource OnDiceSelectedSound;

		public AudioSource OnCameraRotateSound;
		public AudioSource OnOpenMenuSound;

		public AudioSource OnDiceFocusSound;

		public List<AudioSource> AllSoundEffects = new List<AudioSource>();

		[SerializeField] private UIManager UIManager;

		public void Initialized()
		{
			if(IsInit) return;
			IsInit = true;
            
			Bgm.Play();

			UIManager = ServiceLocator.Instance.Get<UIManager>();

			var _menuUI = UIManager.GetUI<MenuUI>();
			
			_menuUI.BGMSlider.onValueChanged.AddListener(_value =>
			{
				Bgm.volume = _value;
			});
			
			_menuUI.SFXSlider.onValueChanged.AddListener(_value =>
			{
				foreach (var _sound in AllSoundEffects)
				{
					_sound.volume = _value;
				}
			});
		}
	}
}
