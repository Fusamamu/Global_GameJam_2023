using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam
{
    public class ToolTipUI : MonoBehaviour, IGameUI
    {
        [field: SerializeField] public bool IsInit { get; private set; }
        
        [field: SerializeField] public Canvas UICanvas { get; private set; }

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
            
            // var _mainCamera = CameraManager.DiceCamera;
            //
            // var _screenPoint = RectTransformUtility.WorldToScreenPoint(_mainCamera, _dice.transform.position);
            // RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.GetComponent<RectTransform>(), _screenPoint, _mainCamera, out var _anchorPos);
            //
            // SomeUI.anchoredPosition3D = _anchorPos;
        }
        
        public void Hide()
        {
            SomeUI.gameObject.SetActive(false);
        }
    }
}
