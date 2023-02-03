using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam
{
    public class ServiceLocator : MonoBehaviour
    {
        public static ServiceLocator Instance;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Debug.LogWarning("More than one service locator !");
                Destroy(this);
                
                return;
            }
            
            Instance = this;
        }

        private readonly Dictionary<string, IService> services = new Dictionary<string, IService>();

        public void Initialized()
        {
            foreach (var _kvp in services)
            {
                _kvp.Value.Initialized();
            }
        }
        
        public T Get<T>() where T : IService
        {
            string _key = typeof(T).Name;
            
            if (!services.ContainsKey(_key))
            {
                Debug.LogError($"{_key} not registered with {GetType().Name}");
                return default;
            }

            return (T)services[_key];
        }
        
        public void Register<T>(T _service) where T : IService
        {
            string _key = typeof(T).Name;
            
            if (services.ContainsKey(_key))
            {
                Debug.LogError($"Attempted to register service of type {_key} which is already registered with the {GetType().Name}.");
                return;
            }

            services.Add(_key, _service);
        }
    }
}
