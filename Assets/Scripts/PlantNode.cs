using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;

namespace GlobalGameJam
{
    public class PlantNode : GridNode
    {
        public bool IsInit;

        public bool IsGrown;
        
        [SerializeField] private SeedNode SeedNodePrefab;
        [SerializeField] private Edge     EdgePrefab;
        
        [SerializeField] private List<SeedInfo> Seeds = new List<SeedInfo>();
        
        [SerializeField] private MMF_Player OnActive;
        
        public void Initialized()
        {
            if(IsInit) return;
            IsInit = true;
            
            OnActive.Initialization();
        }

        public void StartGrow()
        {
            StartCoroutine(Grow());
        }
        
        public IEnumerator Grow()
        {
            IsGrown = true;
            
            var _index = 0;
            
            while (_index < Seeds.Count)
            {
                var _newEdge = Instantiate(EdgePrefab, GridPos, Quaternion.identity);

                _newEdge.Initialized();
                
                _newEdge.SetEnd(Seeds[_index].TargetPos);
                
                _newEdge.PlayFeedback();
                
                yield return new WaitForSeconds(0.5f);
                
                var _newSeedNode = CreateSeedNode(GridPos + Seeds[_index].TargetPos);

                _newSeedNode.PlayFeedback();
                _index++;
                
                yield return new WaitForSeconds(1);
            }
        }
        
        
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
