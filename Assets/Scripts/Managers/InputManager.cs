using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GlobalGameJam
{
    public class InputManager : MonoBehaviour, IService
    {
        public bool IsInit { get; private set; }
        
        public GameplayInput GameplayInput { get; private set; }
       
        public void Initialized()
        {
            if(IsInit) return;
            IsInit = true;
            
            GameplayInput = new GameplayInput();
            
            GameplayInput.Enable();
        }
    }
}
