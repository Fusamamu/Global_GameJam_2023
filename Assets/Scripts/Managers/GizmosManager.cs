using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam
{
    public class GizmosManager : MonoBehaviour, IService
    {
        [field: SerializeField] public bool IsInit { get; private set; }

        [SerializeField] private RangeGizmos RangeGizmos;

        private Dictionary<string, IGizmos> gizmosTable = new Dictionary<string, IGizmos>();

        public void Initialized()
        {
            if(IsInit) return;
            IsInit = true;
            
            gizmosTable.Add(typeof(RangeGizmos).Name, RangeGizmos);
        }

        public T Get<T>() where T : Component, IGizmos
        {
            if (gizmosTable.ContainsKey(typeof(T).Name))
            {
                return gizmosTable[typeof(T).Name] as T;
            }

            return null;
        }
    }
}
