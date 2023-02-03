using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam
{
    [CreateAssetMenu(fileName = "Movement", menuName = "ScriptableObjects/Ability Movement", order = 1)]
    public class Movement : Ability
    {
        public enum Direction
        {
            Forward, Left, Right, Back
        }

        [field: SerializeField] public Direction MoveDirection { get; private set; }
        [field: SerializeField] public float Speed     { get; private set; }
        [field: SerializeField] public int   MoveCount { get; private set; }
        
        public override void Init()
        {
        }
        
        public override IEnumerator Perform(IEntity _entity, Action _onCompleted = null)
        {
            int _moveCounter = 0;
            
            while (_moveCounter < MoveCount)
            {
                var _startPos  = _entity.EntityTransform.position;
                var _targetPos = _startPos + GetMoveDirection();

                if (ServiceLocator.Instance.Get<GridDataManager>().CurrentGridLevel.HasNodeAt(_targetPos))
                {
                    _entity.PlayFeedback("");
                    yield return new WaitForSeconds(1f);
                    yield break;
                }
                
                float _t = 0;

                while (_t <= 1)
                {
                    _t += Time.deltaTime * Speed;

                    _entity.EntityTransform.position = Vector3.Lerp(_startPos, _targetPos, _t);

                    yield return null;
                }

                _entity.EntityTransform.position = _targetPos;

                _moveCounter++;
                
                yield return new WaitForSeconds(0.5f);
            }
        }

        private Vector3 GetMoveDirection()
        {
            switch (MoveDirection)
            {
                case Direction.Forward:
                    return Vector3.forward;
                case Direction.Left:
                    return Vector3.left;
                case Direction.Right:
                    return Vector3.right;
                case Direction.Back:
                    return Vector3.back;
            }

            return Vector3.zero;
        }
        
        public override void StopPerform()
        {
        }
    }
}
