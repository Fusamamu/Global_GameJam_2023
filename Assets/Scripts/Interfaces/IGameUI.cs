using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam
{
    public interface IGameUI
    {
        public Canvas UICanvas { get; }
        
        public void Initialized();
        public void Show();
        public void Hide();
    }
}
