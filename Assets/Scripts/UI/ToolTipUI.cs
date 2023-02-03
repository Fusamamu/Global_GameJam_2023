using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam
{
    public class ToolTipUI : MonoBehaviour, IGameUI
    {
        [field: SerializeField] public Canvas UICanvas { get; private set; }
        
        public void Initialized()
        {
            
        }
        
        public void Show()
        {
        }
        
        public void Hide()
        {
            
        }
    }
}
