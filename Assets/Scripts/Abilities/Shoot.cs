using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GlobalGameJam
{
    [CreateAssetMenu(fileName = "Shoot", menuName = "ScriptableObjects/Ability Shoot", order = 1)]
    public class Shoot : Ability
    {
        public Bullet BulletPrefab;
        
        public float Range;

        public int FireCount;

        public float FireInterval;
        
        public override void Init()
        {
        }
        
        public override IEnumerator Perform(IEntity _entity, Action _onCompleted = null)
        {
            ServiceLocator.Instance
                .Get<GizmosManager>()
                .Get<RangeGizmos>()
                .SetRadius(Range)
                .Show();

            yield return new WaitForSeconds(2);
            
            //Temp
            var _allEntities = FindObjectsOfType<MonoBehaviour>().OfType<IEntity>();

            IEntity _foundTarget = null;
            
            foreach (var _obj in _allEntities)
            {
                if(_obj.EntityTransform == _entity.EntityTransform) continue;

                if (Vector3.Distance(_entity.EntityTransform.position, _obj.EntityTransform.position) <= Range)
                {
                    _foundTarget = _obj;
                    break;
                }
            }

            if (_foundTarget != null)
            {
                var _fireCount = FireCount;

                var _shootDir = _foundTarget.EntityTransform.position - _entity.EntityTransform.position;
                
                while (_fireCount > 0)
                {
                    var _bullet = Instantiate(BulletPrefab, _entity.EntityTransform.position, Quaternion.identity);
                    
                    yield return _bullet.Fire(_shootDir, Range);

                    yield return new WaitForSeconds(FireInterval);

                    _fireCount--;
                }
            }

            
            ServiceLocator
                .Instance.Get<GizmosManager>()
                .Get<RangeGizmos>()
                .Hide();
        }
        
        public override void StopPerform()
        {
            
        }
    }
}
