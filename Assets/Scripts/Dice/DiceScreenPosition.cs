using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam
{
    public class DiceScreenPosition : MonoBehaviour
    {
        public Transform BottomCameraScreen;
        
        public float ScreenWidth   => 1 / DiceCamera.WorldToViewportPoint(new Vector3(1, 1, 0)).x - 5f;
        public float ScreenHeight  => 1 / DiceCamera.WorldToViewportPoint(new Vector3(1, 1, 0)).y - 5f;
        
        public float PositionWidth => (ScreenPositions.Count - 1) * HorizontalSpaceInterval;
        
        [field: SerializeField] public float HorizontalSpaceInterval { get; private set; }
        
        public List<Transform> ScreenPositions = new List<Transform>();

        [SerializeField] private Camera DiceCamera;
        
        [SerializeField] private DiceManager   DiceManager;
        [SerializeField] private CameraManager CameraManager;
        
        public void Initialized()
        {
            DiceManager   = ServiceLocator.Instance.Get<DiceManager>();
            CameraManager = ServiceLocator.Instance.Get<CameraManager>();

            DiceCamera = CameraManager.DiceCamera;
        }

        public DiceScreenPosition GenerateDiceScreenPosition(int _positionCount)
        {
            for (int _i = 0; _i < _positionCount; _i++)
            {
                var _positionObject = new GameObject("Screen Point");
                
                _positionObject.transform.SetParent(DiceCamera.transform);

                _positionObject.transform.rotation      = DiceCamera.transform.rotation;

                _positionObject.transform.localPosition = Vector3.zero + new Vector3(_i * HorizontalSpaceInterval, 0, 0) + new Vector3(0, 0, 5);
                
                ScreenPositions.Add(_positionObject.transform);
            }

            foreach (var _pos in ScreenPositions)
            {
                _pos.localPosition -= new Vector3(PositionWidth / 2, 0, 0) - BottomCameraScreen.localPosition;
                //_pos.localPosition -= new Vector3(0, -ScreenHeight, 0);
            }
            
            return this;
        }

        public DiceScreenPosition ClearPositions()
        {
            foreach (var _pos in ScreenPositions)
            {
                if(_pos == null) continue;
                
                if (Application.isPlaying)
                    Destroy(_pos.gameObject);
                else
                    DestroyImmediate(_pos.gameObject);
            }
            
            ScreenPositions.Clear();
            
            return this;
        }
        
#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;

            foreach (var _pos in ScreenPositions)
            {
                Gizmos.DrawSphere(_pos.position, 0.1f);
            }
        }
#endif
    }
}
