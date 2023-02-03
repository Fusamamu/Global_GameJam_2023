using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace GlobalGameJam
{
    public class UIManager : MonoBehaviour, IService
    {
        private Dictionary<Type, IGameUI> uiTable = new Dictionary<Type, IGameUI>();

        public void Initialized()
        {
            var _allUIs = FindObjectsOfType<MonoBehaviour>(true).OfType<IGameUI>();

            foreach (var _ui in _allUIs)
            {
                _ui.Initialized();
                AddUI(_ui);
            }
        }

        public T GetUI<T>() where T : Component, IGameUI
        {
            var _key = typeof(T);

            if (!uiTable.TryGetValue(_key, out var _ui))
                return default;

            return _ui as T;
        }

        public void AddUI(IGameUI _ui)
        {
            var _key = _ui.GetType();
            
            if (!uiTable.ContainsKey(_key))
            {
                uiTable.Add(_key, _ui);
                return;
            }

            uiTable[_key] = _ui;
        }

        public void Show<T>() where T : Component, IGameUI
        {
            var _ui = GetUI<T>() as T;

            if (_ui != null)
                _ui.Show();
        }
        
        public void Hide<T>() where T : Component, IGameUI
        {
            var _ui = GetUI<T>() as T;

            if (_ui != null)
                _ui.Hide();
        }

        public void CloseAllUI()
        {
            foreach (var _kvp in uiTable)
            {
                var _ui = _kvp.Value;
                _ui?.Hide();
            }
        }
    }
}
