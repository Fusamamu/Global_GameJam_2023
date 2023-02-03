using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam
{
    public class GizmosUI : MonoBehaviour, IGameUI
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

        public void Update()
        {
            if(!IsInit) return;
            
            Show();
        }

        public void Show()
        {

            // var _player = FindObjectOfType<Player>();
            //
            // var _mainCamera = CameraManager.MainCamera;
            //
            // var _screenPoint = RectTransformUtility.WorldToScreenPoint(_mainCamera, _player.transform.position);
            // RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.GetComponent<RectTransform>(), _screenPoint, _mainCamera, out var _anchorPos);
            //
            // SomeUI.anchoredPosition3D = _anchorPos;

            // var _towers = structureManager.GetStructures<Tower>();
            //
            // foreach (var _tower in _towers)
            // {
            //     var _iconUI = iconPool?.Get();
            //     
            //     if (_iconUI != null)
            //     {
            //         var _mainCamera  = cameraManager.GetCamera(CameraType._MAIN);
            //         var _screenPoint = RectTransformUtility.WorldToScreenPoint(_mainCamera, _tower.transform.position);
            //
            //         RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.GetComponent<RectTransform>(), _screenPoint, _mainCamera, out var _anchorPos);
            //     
            //         _iconUI.GetRect().anchoredPosition3D = _anchorPos;
            //
            //         _iconUI.Show();
            //     }
            // }
        }
        
        public void Hide()
        {
        }
    }
}
