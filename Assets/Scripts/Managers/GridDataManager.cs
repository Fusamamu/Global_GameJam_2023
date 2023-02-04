using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GlobalGameJam
{
    public class GridDataManager : MonoBehaviour, IService
    {
        [field: SerializeField] public bool IsInit { get; private set; }

        public GridNodeData CurrentGridLevel => GridLevels[ServiceLocator.Instance.Get<LevelManager>().CurrentLevel];

        public List<GridNodeData> GridLevels = new List<GridNodeData>();

        public float LevelChangeSpeed = 1;

        public void Initialized()
        {
            if(IsInit) return;
            IsInit = true;

            foreach (var _level in GridLevels)
            {
                foreach (var _node in _level.Nodes)
                {
                    if(_node == null) continue;
                
                    _node
                        .SetGridNodeData(_level)
                        .SetNeighbors();
                }
                
                _level.gameObject.SetActive(false);
            }

            CurrentGridLevel.gameObject.SetActive(true);
        }

        public void StartChangeNextLevel(Action _onCompleted = null)
        {
            StartCoroutine(ChangeNextLevel(_onCompleted));
        }

        public IEnumerator ChangeNextLevel(Action _onCompleted = null)
        {
            var _t = 0f;
            
            var _startPos  = CurrentGridLevel.transform.position;
            var _targetPos = new Vector3(0, -50, 0);

            while (_t < 1f)
            {
                _t += Time.deltaTime * LevelChangeSpeed;

                CurrentGridLevel.transform.position = Vector3.Lerp(_startPos, _targetPos, _t);

                yield return null;
            }
            
            CurrentGridLevel.gameObject.SetActive(false);

            //not good
            ServiceLocator.Instance.Get<LevelManager>().CurrentLevel++;

            CurrentGridLevel.gameObject.SetActive(true);
            CurrentGridLevel.transform.position = new Vector3(0, -50, 0);
            
            var _nextLevelStartPos  = CurrentGridLevel.transform.position;
            var _nextLevelTargetPos = new Vector3(0, 0, 0);

            _t = 0f;

            while (_t < 1f)
            {
                _t += Time.deltaTime * LevelChangeSpeed;

                CurrentGridLevel.transform.position = Vector3.Lerp(_nextLevelStartPos, _nextLevelTargetPos, _t);

                yield return null;
            }
            
            _onCompleted?.Invoke();
        }

        public bool IsAllPlantNodesGrown()
        {
            var _plantNodes = CurrentGridLevel.Nodes.ToList().Where(_node => _node != null).Where(_node => _node.NodeType == NodeType.PLANTBASE);

            foreach (var _node in _plantNodes)
            {
                if (_node.TryGetComponent<PlantNode>(out var _plant))
                {
                    if (!_plant.Growing)
                        return false;
                }
            }

            return true;
        }
    }
}
