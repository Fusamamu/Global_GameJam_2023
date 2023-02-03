using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam
{
    public class Bullet : MonoBehaviour
    {
        public float Speed;
        public float DamagePoint;

        public ColliderController ColliderController;

        private Coroutine fireProcess;
        
        public IEnumerator Fire(Vector3 _dir, float _distance)
        {
            float _t = 0;
            
            var _startPos  = transform.position;
            var _targetPos = _startPos + _dir.normalized * _distance;

            while (_t <= 1)
            {
                _t += Time.deltaTime * Speed;

                transform.position = Vector3.Lerp(_startPos, _targetPos, _t);

                yield return null;
            }

            transform.position = _targetPos;
            
            gameObject.SetActive(false);
        }

        private void OnTriggerEnter(Collider _other)
        {
            if (_other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                if (_other.gameObject.TryGetComponent<Enemy>(out var _enemy))
                {
                    _enemy.PlayFeedback("OnHit");
                }
                
                //Destroy(gameObject);
                gameObject.SetActive(false);
            }
        }
    }
}
