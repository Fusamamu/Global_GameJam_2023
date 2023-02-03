using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam
{
    public interface IGizmos
    {
        public void Initialized();
        public IGizmos Show();
        public IGizmos Hide();
    }
}
