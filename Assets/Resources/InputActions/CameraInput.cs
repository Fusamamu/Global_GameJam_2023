//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Resources/InputActions/CameraInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @CameraInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @CameraInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CameraInput"",
    ""maps"": [
        {
            ""name"": ""MainCamera"",
            ""id"": ""09aa863f-0954-40d7-9581-a6d06cbd6e7e"",
            ""actions"": [
                {
                    ""name"": ""MoveLeft"",
                    ""type"": ""Button"",
                    ""id"": ""2a3904d1-8f04-40a8-9c05-ea5e684cc96e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveRight"",
                    ""type"": ""Button"",
                    ""id"": ""1aafca5b-2835-4430-9ad2-dcab2175afdc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveUp"",
                    ""type"": ""Button"",
                    ""id"": ""866e5074-f201-4fe9-a4ce-ca1630de5bdf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveDown"",
                    ""type"": ""Button"",
                    ""id"": ""9990aa38-07a1-4c6b-b03b-a53bde8e8479"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ZoomIn"",
                    ""type"": ""Button"",
                    ""id"": ""c85b9322-1dd2-4a12-bc73-c004ca7e3b3e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ZoomOut"",
                    ""type"": ""Button"",
                    ""id"": ""a2d2a408-b2e6-4e04-85d5-eac9e5a9d2f6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""QuickRotateCW"",
                    ""type"": ""Button"",
                    ""id"": ""d126b9a3-30a9-4381-9bc1-bf4c7440d8e0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""QuickRotateCCW"",
                    ""type"": ""Button"",
                    ""id"": ""e57537ca-6604-4407-8e37-0d69083eb9c6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fedb57a5-1a8f-4631-ad15-8359659d3262"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7a5cb62e-5eff-4f98-9718-80973c1a0e8d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c760caad-c94e-4a83-9015-defafcb4c9fe"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bebd30f2-a95a-4a5b-a2b4-07eb0489ab04"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cf5667c1-252d-4982-b6af-e8f7b9acbe45"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ZoomIn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""66a0d09c-4239-45f1-a629-a5384ea37026"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ZoomOut"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""809a1bd7-ddf8-4761-8684-3f2a7b2d25a7"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""QuickRotateCW"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""935f0c51-8d76-46ad-8d8e-89000791d72a"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""QuickRotateCCW"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // MainCamera
        m_MainCamera = asset.FindActionMap("MainCamera", throwIfNotFound: true);
        m_MainCamera_MoveLeft = m_MainCamera.FindAction("MoveLeft", throwIfNotFound: true);
        m_MainCamera_MoveRight = m_MainCamera.FindAction("MoveRight", throwIfNotFound: true);
        m_MainCamera_MoveUp = m_MainCamera.FindAction("MoveUp", throwIfNotFound: true);
        m_MainCamera_MoveDown = m_MainCamera.FindAction("MoveDown", throwIfNotFound: true);
        m_MainCamera_ZoomIn = m_MainCamera.FindAction("ZoomIn", throwIfNotFound: true);
        m_MainCamera_ZoomOut = m_MainCamera.FindAction("ZoomOut", throwIfNotFound: true);
        m_MainCamera_QuickRotateCW = m_MainCamera.FindAction("QuickRotateCW", throwIfNotFound: true);
        m_MainCamera_QuickRotateCCW = m_MainCamera.FindAction("QuickRotateCCW", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // MainCamera
    private readonly InputActionMap m_MainCamera;
    private IMainCameraActions m_MainCameraActionsCallbackInterface;
    private readonly InputAction m_MainCamera_MoveLeft;
    private readonly InputAction m_MainCamera_MoveRight;
    private readonly InputAction m_MainCamera_MoveUp;
    private readonly InputAction m_MainCamera_MoveDown;
    private readonly InputAction m_MainCamera_ZoomIn;
    private readonly InputAction m_MainCamera_ZoomOut;
    private readonly InputAction m_MainCamera_QuickRotateCW;
    private readonly InputAction m_MainCamera_QuickRotateCCW;
    public struct MainCameraActions
    {
        private @CameraInput m_Wrapper;
        public MainCameraActions(@CameraInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveLeft => m_Wrapper.m_MainCamera_MoveLeft;
        public InputAction @MoveRight => m_Wrapper.m_MainCamera_MoveRight;
        public InputAction @MoveUp => m_Wrapper.m_MainCamera_MoveUp;
        public InputAction @MoveDown => m_Wrapper.m_MainCamera_MoveDown;
        public InputAction @ZoomIn => m_Wrapper.m_MainCamera_ZoomIn;
        public InputAction @ZoomOut => m_Wrapper.m_MainCamera_ZoomOut;
        public InputAction @QuickRotateCW => m_Wrapper.m_MainCamera_QuickRotateCW;
        public InputAction @QuickRotateCCW => m_Wrapper.m_MainCamera_QuickRotateCCW;
        public InputActionMap Get() { return m_Wrapper.m_MainCamera; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainCameraActions set) { return set.Get(); }
        public void SetCallbacks(IMainCameraActions instance)
        {
            if (m_Wrapper.m_MainCameraActionsCallbackInterface != null)
            {
                @MoveLeft.started -= m_Wrapper.m_MainCameraActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.performed -= m_Wrapper.m_MainCameraActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.canceled -= m_Wrapper.m_MainCameraActionsCallbackInterface.OnMoveLeft;
                @MoveRight.started -= m_Wrapper.m_MainCameraActionsCallbackInterface.OnMoveRight;
                @MoveRight.performed -= m_Wrapper.m_MainCameraActionsCallbackInterface.OnMoveRight;
                @MoveRight.canceled -= m_Wrapper.m_MainCameraActionsCallbackInterface.OnMoveRight;
                @MoveUp.started -= m_Wrapper.m_MainCameraActionsCallbackInterface.OnMoveUp;
                @MoveUp.performed -= m_Wrapper.m_MainCameraActionsCallbackInterface.OnMoveUp;
                @MoveUp.canceled -= m_Wrapper.m_MainCameraActionsCallbackInterface.OnMoveUp;
                @MoveDown.started -= m_Wrapper.m_MainCameraActionsCallbackInterface.OnMoveDown;
                @MoveDown.performed -= m_Wrapper.m_MainCameraActionsCallbackInterface.OnMoveDown;
                @MoveDown.canceled -= m_Wrapper.m_MainCameraActionsCallbackInterface.OnMoveDown;
                @ZoomIn.started -= m_Wrapper.m_MainCameraActionsCallbackInterface.OnZoomIn;
                @ZoomIn.performed -= m_Wrapper.m_MainCameraActionsCallbackInterface.OnZoomIn;
                @ZoomIn.canceled -= m_Wrapper.m_MainCameraActionsCallbackInterface.OnZoomIn;
                @ZoomOut.started -= m_Wrapper.m_MainCameraActionsCallbackInterface.OnZoomOut;
                @ZoomOut.performed -= m_Wrapper.m_MainCameraActionsCallbackInterface.OnZoomOut;
                @ZoomOut.canceled -= m_Wrapper.m_MainCameraActionsCallbackInterface.OnZoomOut;
                @QuickRotateCW.started -= m_Wrapper.m_MainCameraActionsCallbackInterface.OnQuickRotateCW;
                @QuickRotateCW.performed -= m_Wrapper.m_MainCameraActionsCallbackInterface.OnQuickRotateCW;
                @QuickRotateCW.canceled -= m_Wrapper.m_MainCameraActionsCallbackInterface.OnQuickRotateCW;
                @QuickRotateCCW.started -= m_Wrapper.m_MainCameraActionsCallbackInterface.OnQuickRotateCCW;
                @QuickRotateCCW.performed -= m_Wrapper.m_MainCameraActionsCallbackInterface.OnQuickRotateCCW;
                @QuickRotateCCW.canceled -= m_Wrapper.m_MainCameraActionsCallbackInterface.OnQuickRotateCCW;
            }
            m_Wrapper.m_MainCameraActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveLeft.started += instance.OnMoveLeft;
                @MoveLeft.performed += instance.OnMoveLeft;
                @MoveLeft.canceled += instance.OnMoveLeft;
                @MoveRight.started += instance.OnMoveRight;
                @MoveRight.performed += instance.OnMoveRight;
                @MoveRight.canceled += instance.OnMoveRight;
                @MoveUp.started += instance.OnMoveUp;
                @MoveUp.performed += instance.OnMoveUp;
                @MoveUp.canceled += instance.OnMoveUp;
                @MoveDown.started += instance.OnMoveDown;
                @MoveDown.performed += instance.OnMoveDown;
                @MoveDown.canceled += instance.OnMoveDown;
                @ZoomIn.started += instance.OnZoomIn;
                @ZoomIn.performed += instance.OnZoomIn;
                @ZoomIn.canceled += instance.OnZoomIn;
                @ZoomOut.started += instance.OnZoomOut;
                @ZoomOut.performed += instance.OnZoomOut;
                @ZoomOut.canceled += instance.OnZoomOut;
                @QuickRotateCW.started += instance.OnQuickRotateCW;
                @QuickRotateCW.performed += instance.OnQuickRotateCW;
                @QuickRotateCW.canceled += instance.OnQuickRotateCW;
                @QuickRotateCCW.started += instance.OnQuickRotateCCW;
                @QuickRotateCCW.performed += instance.OnQuickRotateCCW;
                @QuickRotateCCW.canceled += instance.OnQuickRotateCCW;
            }
        }
    }
    public MainCameraActions @MainCamera => new MainCameraActions(this);
    public interface IMainCameraActions
    {
        void OnMoveLeft(InputAction.CallbackContext context);
        void OnMoveRight(InputAction.CallbackContext context);
        void OnMoveUp(InputAction.CallbackContext context);
        void OnMoveDown(InputAction.CallbackContext context);
        void OnZoomIn(InputAction.CallbackContext context);
        void OnZoomOut(InputAction.CallbackContext context);
        void OnQuickRotateCW(InputAction.CallbackContext context);
        void OnQuickRotateCCW(InputAction.CallbackContext context);
    }
}