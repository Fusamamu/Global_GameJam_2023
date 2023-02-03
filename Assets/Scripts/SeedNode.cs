using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;

namespace GlobalGameJam
{
    [Serializable]
    public struct SeedInfo
    {
        public Vector3Int TargetPos;
    }
    
    public class SeedNode : GridNode
    {
        public bool Growing;
        
        public bool IsInit;
        
        [SerializeField] private SeedNode SeedNodePrefab;
        [SerializeField] private Edge     EdgePrefab;

        [SerializeField] private List<SeedInfo> Seeds = new List<SeedInfo>();

        [SerializeField] private MMF_Player OnActive;

        public static Action OnAllPlantGrown = delegate { };

        public void Initialized()
        {
            if(IsInit) return;
            IsInit = true;
            
            OnActive.Initialization();
        }

        public void StartGrow()
        {
            Growing = true;
            StartCoroutine(Grow());
        }
        
        public IEnumerator Grow()
        {
            var _index = 0;
            
            while (_index < Seeds.Count)
            {
                var _targetPos = GridPos + Seeds[_index].TargetPos;

                var _targetNode = GridNodeData.AtPos(_targetPos);
                if (_targetNode != null)
                {
                    if (_targetNode.NodeType == NodeType.PLANTBASE)
                    {
                        if (_targetNode.TryGetComponent<PlantNode>(out var _plantNode))
                        {
                            _plantNode.Initialized();
                            _plantNode.StartGrow();
                            
                            ServiceLocator.Instance.Get<AudioManager>().OnPlantConnectedSound.Play();

                            if (ServiceLocator.Instance.Get<GridDataManager>().IsAllPlantNodesGrown())
                            {
                                OnAllPlantGrown?.Invoke();
                            }
                        }
                    }
                }
                
                var _newEdge = Instantiate(EdgePrefab, GridPos, Quaternion.identity, GridNodeData.transform);

                _newEdge.Initialized();
                
                _newEdge.SetEnd(Seeds[_index].TargetPos);
                
                _newEdge.PlayFeedback();
                
                yield return new WaitForSeconds(0.5f);
                
                var _newSeedNode = CreateSeedNode(GridPos + Seeds[_index].TargetPos);

                _newSeedNode.PlayFeedback();
                _index++;
                
                ServiceLocator.Instance.Get<AudioManager>().GrowingNodeSound.Play();
                
                yield return new WaitForSeconds(1);
            }

            Growing = false;
        }

        //need to use base function
        public SeedNode CreateSeedNode(Vector3Int _targetPos)
        {
            var _seedNode = Instantiate(SeedNodePrefab, _targetPos, Quaternion.identity, GridNodeData.transform);

            _seedNode.Initialized();
            
            _seedNode
                .SetGridPos(_targetPos)
                .SetWorldPos(_targetPos);
            
            GridNodeData.AddNode(_seedNode, _targetPos);
            
            return _seedNode;
        }

        public void PlayFeedback(string _feedback = "")
        {
            OnActive.PlayFeedbacks();
        }
    }
}
