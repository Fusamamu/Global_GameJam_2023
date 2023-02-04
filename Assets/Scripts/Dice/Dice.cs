using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Pool;

namespace GlobalGameJam
{
    public class Dice : MonoBehaviour
    {
        public bool IsInit { get; private set; }

        public bool IsSelected;

        public SeedNode SeedNodePrefab;

        public float CoolDown;
        
        [SerializeField] private List<Transform> Sides = new List<Transform>();
        
        public enum Side
        {
            ONE, TWO, THREE, FOUR, FIVE, SIX
        }
        
        public bool IsRolling => ColliderController.Rigidbody.velocity.magnitude > 0f;
        
        [field: SerializeField] public Side CurrentSide { get; private set; }
        [field: SerializeField] public ColliderController ColliderController { get; private set; }
        
        [SerializeField] private CameraManager CameraManager;
        [SerializeField] private UIManager UIManager;

        private IObjectPool<Dice> pool;

        private Coroutine facingCameraCoroutine;
        private Coroutine moveCoroutine;

        [SerializeField] private bool IsFocus;
        [SerializeField] private MMF_Player OnFocusFeedback;
        [SerializeField] private MMF_Player OnSelectedFeedback;

        [SerializeField] private float GizmosSize;

        public static event Action OnDiceSelected = delegate { };
        
        public void Initialized()
        {
            if(IsInit) return;
            IsInit = true;
            
            CameraManager = ServiceLocator.Instance.Get<CameraManager>();
            UIManager     = ServiceLocator.Instance.Get<UIManager>();
            
            OnSelectedFeedback.Events.OnComplete.AddListener(() =>
            {
                ColliderController.DisableRigidBody();
                pool?.Release(this);
            });
        }

        public void Roll()
        {
            ColliderController.EnableRigidBody();
            RandomSpin();
            ColliderController.Rigidbody.AddForce(new Vector3(0, -10, 0), ForceMode.Impulse);
        }

        public void SetPool(IObjectPool<Dice> _pool)
        {
            pool = _pool;
        }

        public void RandomSpin()
        {
            var _rotation = new Vector3(45, 45, 45);
            
            ColliderController.Rigidbody.AddRelativeTorque(_rotation, ForceMode.Impulse);
        }

        public IEnumerator SetPosition(Vector3 _targetPos, Action<Dice> _onCompleted = null)
        {
            StopAllCoroutines();
            
            facingCameraCoroutine = StartCoroutine(FaceCurrentSideToCamera());
            moveCoroutine         = StartCoroutine(GoToPos(_targetPos));

            yield return facingCameraCoroutine;
            yield return moveCoroutine;

            _onCompleted?.Invoke(this);
        }

        public IEnumerator FaceCurrentSideToCamera()
        {
            var _diceCamera = CameraManager.DiceCamera;

            var _startRotation = transform.rotation;
            //var _finalRotation = _diceCamera.transform.rotation;
            
            var _finalRotation = Quaternion.Euler(74.2f, 23.3f, 0f);

            var _t = 0f;

            while (_t <= 1f)
            {
                _t += Time.deltaTime;// / timeToRotate;
                transform.rotation = Quaternion.Lerp(_startRotation, _finalRotation, _t);
                yield return null;
            }

            transform.rotation = _finalRotation;
        }

        public IEnumerator GoToPos(Vector3 _targetPos)
        {
            var _startPos = transform.position;

            var _t = 0f;

            while (_t <= 1f)
            {
                _t += Time.deltaTime * 3.5f;
                transform.position = Vector3.Lerp(_startPos, _targetPos, _t);
                yield return null;
            }

            transform.position = _targetPos;

            ColliderController.EnableCollider();
            
            ServiceLocator.Instance.Get<AudioManager>().OnDiceSnapToPosSound.Play();
        }

        public void OnUnableToSelect()
        {
            ColliderController.DisableCollider();
            ColliderController.DisableRigidBody();
            OnFocusFeedback.PlayFeedbacks();
            
            ServiceLocator.Instance.Get<AudioManager>().OnDiceUnableToSelectSound.Play();
        }

        public void OnSelected()
        {
            ColliderController.DisableCollider();
            ColliderController.DisableRigidBody();
            OnSelectedFeedback.PlayFeedbacks();

            IsSelected = true;
            
            ServiceLocator.Instance.Get<AudioManager>().OnDiceSelectedSound.Play();
         
            OnDiceSelected?.Invoke();
        }

        public void OnFocus()
        {
            if(CoolDown > 0) return;

            if(IsFocus) return;
            IsFocus = true;
            
            if (OnFocusFeedback.IsPlaying)
                OnFocusFeedback.StopFeedbacks();
            
            OnFocusFeedback.Direction = MMFeedbacks.Directions.TopToBottom;
            OnFocusFeedback.PlayFeedbacks();
            
            UIManager.GetUI<ToolTipUI>().Show(this);
            
            ServiceLocator.Instance.Get<AudioManager>().OnDiceFocusSound.Play();
        }

        public void OnLostFocus()
        {
            if(!IsFocus) return;
            IsFocus = false;
            
            if (OnFocusFeedback.IsPlaying)
                OnFocusFeedback.StopFeedbacks();
            
            OnFocusFeedback.PlayFeedbacksInReverse();
            
            CoolDown = 0.16f;
            
            UIManager.GetUI<ToolTipUI>().Hide();
        }

        private void Update()
        {
            if (CoolDown > 0f)
            {
                CoolDown -= Time.deltaTime;
            }
        }

        private void FixedUpdate()
        {
            if (ColliderController.Rigidbody.velocity.magnitude == 0)
            {
                var _side  = Sides.OrderByDescending(_side => _side.position.y).FirstOrDefault();
                var _index = Sides.IndexOf(_side);
                CurrentSide = (Side)_index;
            }
        }

        private void OnDestroy()
        {
            pool?.Release(this);
        }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            if(Sides.Count < 6) return;
            
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(Sides[0].position, GizmosSize);
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(Sides[1].position, GizmosSize);
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(Sides[2].position, GizmosSize);
            Gizmos.color = Color.cyan;
            Gizmos.DrawSphere(Sides[3].position, GizmosSize);
            Gizmos.color = Color.black;
            Gizmos.DrawSphere(Sides[4].position, GizmosSize);
            Gizmos.color = Color.magenta;
            Gizmos.DrawSphere(Sides[5].position, GizmosSize);
        }
#endif
    }
}
