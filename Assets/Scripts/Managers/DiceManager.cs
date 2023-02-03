using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Pool;

namespace GlobalGameJam
{
    public class DiceManager : MonoBehaviour, IService
    {
        public int DiceCount => Dices.Count;
        
        [field: SerializeField] public int DiceMaxCount { get; private set; }

        public List<Dice> Dices = new List<Dice>();

        [SerializeField] private Transform SpawnPos;

        [SerializeField] private Dice DicePrefab;
        
        private IObjectPool<Dice> dicePool;

        public bool IsEnable;
        public bool StartRoll;
        
        [SerializeField] private float MaxRollTimer;
        [SerializeField] private float RollTimer;

        [ReadOnly, SerializeField] private LevelManager LevelManager;
        [ReadOnly, SerializeField] private DiceSelection      DiceSelection;
        [ReadOnly, SerializeField] private DiceScreenPosition DiceScreenPosition;
        [ReadOnly, SerializeField] private InputManager InputManager;

        public event Action OnDiceStopRolling = delegate { };

        public bool AllDicesSelected()
        {
            foreach (var _dice in Dices)
            {
                if (_dice == null) continue;

                if (!_dice.IsSelected)
                    return false;
            }

            return true;
        }

        public void Initialized()
        {
            dicePool = new ObjectPool<Dice>(OnDiceCreated, OnGetDice, OnDiceReleased, OnDiceDestroyed);

            LevelManager = ServiceLocator.Instance.Get<LevelManager>();
            
            InputManager = ServiceLocator.Instance.Get<InputManager>();

            InputManager.GameplayInput.Dice.RollDice.performed -= RollDice;
            InputManager.GameplayInput.Dice.RollDice.performed += RollDice;
        }

        public void RollDice(InputAction.CallbackContext _context)
        {
            if(!IsEnable) return;
            
            ServiceLocator.Instance.Get<UIManager>().GetUI<LevelUI>().PressSpaceBarUI.SetActive(false);

            SetDiceCount(1)
                .ClearDices()
                .CreateDices()
                .StartRollDice()
                .Disable();

            LevelManager.CurrentBatch++;
        }

        public DiceManager Enable()
        {
            IsEnable = true;
            return this;
        }

        public DiceManager Disable()
        {
            IsEnable = false;
            return this;
        }

        public DiceManager StartRollDice()
        {
            foreach (var _dice in Dices)
            {
                _dice.Roll();
            }
            
            StartRoll = true;
            
            return this;
        }

        public DiceManager ApplyAllDices(Action<Dice> _action)
        {
            foreach (var _dice in Dices)
            {
                if(_dice == null) continue;
                _action?.Invoke(_dice);
            }
            return this;
        }

        public DiceManager SetDiceCount(int _count)
        {
            DiceMaxCount = _count;
            return this;
        }

        public DiceManager CreateDices()
        {
            CreateDices(LevelManager.SeedCount());
            return this;
        }

        public DiceManager CreateDices(int _count)
        {
            for (var _i = 0; _i < _count; _i++)
            {
                var _dice = dicePool?.Get();

                if (_dice)
                {
                    _dice.transform.position = SpawnPos.position;
                    
                    _dice.ColliderController
                        .EnableCollider()
                        .EnableRigidBody();

                    _dice.IsSelected = false;

                    _dice.SeedNodePrefab = LevelManager.GetSeeds().SeedNodes[_i];
                    
                    Dices.Add(_dice);
                }
            }

            return this;
        }

        public DiceManager ClearDices()
        {
            foreach (var _dice in Dices)
                Destroy(_dice.gameObject);
            
            Dices.Clear();

            return this;
        }

        private void FixedUpdate()
        {
            if (!StartRoll) return;
                
            if (RollTimer > 0)
            {
                RollTimer -= Time.deltaTime;
                return;
            }
            
            if (IsAllDicesStopRolling())
            {
                foreach (var _dice in Dices)
                {
                    _dice
                        .ColliderController
                        .DisableRigidBody();
                }

                DiceScreenPosition
                    .ClearPositions()
                    .GenerateDiceScreenPosition(DiceCount);

                for (int _i = 0; _i < DiceScreenPosition.ScreenPositions.Count; _i++)
                {
                    var _dice   = Dices[_i];
                    var _target = DiceScreenPosition.ScreenPositions[_i];

                    var _targetWorldPos = _target.position;
                    StartCoroutine(_dice.SetPosition(_targetWorldPos));
                }

                StartRoll = false;
                RollTimer = MaxRollTimer;
                
                OnDiceStopRolling?.Invoke();
            }
        }

        public bool IsAllDicesStopRolling()
        {
            foreach (var _dice in Dices)
            {
                if(_dice == null) continue;

                if (_dice.IsRolling)
                    return false;
            }

            return true;
        }

        private Dice OnDiceCreated()
        {
            var _newDice = Instantiate(DicePrefab, Vector3.zero, Quaternion.identity);
            _newDice.Initialized();
            return _newDice;
        }

        private void OnGetDice(Dice _dice)
        {
            _dice.gameObject.SetActive(true);
        }

        private void OnDiceReleased(Dice _dice)
        {
            _dice.gameObject.SetActive(false);
        }

        private void OnDiceDestroyed(Dice _dice)
        {
            Destroy(_dice.gameObject);
        }

        private void OnDestroy()
        {
            InputManager.GameplayInput.Dice.RollDice.performed -= RollDice;
        }
    }
}
