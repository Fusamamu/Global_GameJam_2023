using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam
{
    public interface IUIElement
    {
        public void Initialized();
        public IUIElement Show();
        public IUIElement Hide();
    }
}
