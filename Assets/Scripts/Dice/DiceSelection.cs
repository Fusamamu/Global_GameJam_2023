using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GlobalGameJam
{
    public class DiceSelection : MonoBehaviour
    {
        [field: SerializeField] public bool IsEnable { get; private set; }

        [SerializeField] private DiceManager   DiceManager;
        [SerializeField] private CameraManager CameraManager;
        [SerializeField] private Camera DiceCamera;

        public Dice CurrentFocusDice;
        
        public void Initialized()
        {
            DiceManager   = ServiceLocator.Instance.Get<DiceManager>();
            CameraManager = ServiceLocator.Instance.Get<CameraManager>();

            DiceCamera = CameraManager.DiceCamera;
        }

        public void Enable()
        {
            IsEnable = true;
        }

        public void Disable()
        {
            IsEnable = false;
        }

        private void Update()
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                if (CurrentFocusDice != null)
                {
                    ServiceLocator.Instance
                        .Get<SeedPlacementManager>()
                        .Enable()
                        .GrabSeedNode(CurrentFocusDice.SeedNodePrefab);
                    
                    CurrentFocusDice.OnSelected();
                    CurrentFocusDice = null;
                }
            }
        }

        private void FixedUpdate()
        {
            if(!IsEnable) return;

            Ray _ray = DiceCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            
            if (Physics.Raycast(_ray, out var _hit, 1000f))
            {
                if (_hit.collider.TryGetComponent<Dice>(out CurrentFocusDice))
                {
                    CurrentFocusDice.OnFocus();
                }
                else
                {
                    foreach (var _eachDice in DiceManager.Dices)
                    {
                        _eachDice.OnLostFocus();
                    }
                }
            }
            else
            {
                foreach (var _eachDice in DiceManager.Dices)
                {
                    _eachDice.OnLostFocus();
                }
            }
        }

    }
}
