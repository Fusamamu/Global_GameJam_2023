using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GlobalGameJam
{
    public class ToolTipUI : MonoBehaviour, IGameUI
    {
        [field: SerializeField] public bool IsInit { get; private set; }
        
        [field: SerializeField] public Canvas UICanvas { get; private set; }

        public TextMeshProUGUI ToolTipText;

        public RectTransform SomeUI;

        [SerializeField] private CameraManager CameraManager;
        
        public void Initialized()
        {
            if(IsInit) return;
            IsInit = true;
            CameraManager = ServiceLocator.Instance.Get<CameraManager>();
        }
        
        public void Show()
        {
        }

        public void Update()
        {
            if(!IsInit) return;
            
        }

        public void Show(Dice _dice)
        {
            SomeUI.gameObject.SetActive(true);
            
            ToolTipText.SetText(_dice.SeedNodePrefab.SeedInformation);
        }
        
        public void Hide()
        {
            SomeUI.gameObject.SetActive(false);
        }
    }
}
