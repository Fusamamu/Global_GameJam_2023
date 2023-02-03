using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam
{
    public class ToolTip : MonoBehaviour, IUIElement
    {

        public void Initialized()
        {
            
        }

        public IUIElement Show()
        {
            return this;
        }
        public IUIElement Hide()
        {
            return this;
        }
    }
}
