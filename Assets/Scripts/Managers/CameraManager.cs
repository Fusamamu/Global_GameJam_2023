using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GlobalGameJam
{
    public class CameraManager : MonoBehaviour, IService
    {
        public Camera MainCamera;
        public Camera DiceCamera;

        [SerializeField] private Transform CameraPivot;

        private CameraInput cameraInput;

        [SerializeField] private MMF_Player OnChangeBackgroundColor;

        [SerializeField] private MMF_Player RotateCCW;
        [SerializeField] private MMF_Player RotateCW;

        public List<Color> BackgroundColors = new List<Color>();

        public void Initialized()
        {
            MainCamera.transform.SetParent(CameraPivot);
            
            cameraInput = new CameraInput();
            
            cameraInput.MainCamera.Enable();

            cameraInput.MainCamera.MoveLeft .performed += MoveLeft;
            cameraInput.MainCamera.MoveRight.performed += MoveRight;
            cameraInput.MainCamera.MoveUp   .performed += MoveUp;
            cameraInput.MainCamera.MoveDown .performed += MoveDown;

            cameraInput.MainCamera.QuickRotateCW .performed += QuickRotateCW;
            cameraInput.MainCamera.QuickRotateCCW.performed += QuickRotateCCW;

            if (OnChangeBackgroundColor != null)
            {
                OnChangeBackgroundColor.Initialization();
            }
        }

        public void ChangeBackgroundColor()
        {
            var _currentColor = MainCamera.backgroundColor;
            var _newColor = BackgroundColors[ServiceLocator.Instance.Get<LevelManager>().CurrentLevel];

            MMF_Property _property = OnChangeBackgroundColor.GetFeedbackOfType<MMF_Property>();
            _property.Target.ColorRemapZero = _currentColor;
            _property.Target.ColorRemapOne  = _newColor;
            
            OnChangeBackgroundColor.PlayFeedbacks();

            // MMF_Property _property = ShowFeedback.GetFeedbackOfType<MMF_Property>();
            // _property.RemapLevelOne = Radius;
            // ShowFeedback.PlayFeedbacks();
        }

        private void MoveLeft(InputAction.CallbackContext _context)
        {
            
        }
        
        private void MoveRight(InputAction.CallbackContext _context)
        {
            
        }
        
        private void MoveUp(InputAction.CallbackContext _context)
        {
            
        }
        
        private void MoveDown(InputAction.CallbackContext _context)
        {
            
        }

        private void QuickRotateCW(InputAction.CallbackContext _context)
        {
            if(RotateCW.IsPlaying) return;
            RotateCW.PlayFeedbacks();
            
            ServiceLocator.Instance.Get<AudioManager>().OnCameraRotateSound.Play();
        }
        
        private void QuickRotateCCW(InputAction.CallbackContext _context)
        {
            if(RotateCCW.IsPlaying) return;
            RotateCCW.PlayFeedbacks();
            
            ServiceLocator.Instance.Get<AudioManager>().OnCameraRotateSound.Play();
        }
    }
}
