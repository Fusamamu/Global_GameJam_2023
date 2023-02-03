using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam
{
    public enum Adjacent
    {
        N, E, W, S, 
        NE, NW, SE, SW, 
        UN, UE, UW, US, 
        UNE, UNW, USE, USW,
        LN, LE, LW, LS,
        LNE, LNW, LSE, LSW
    }

    public enum NodeType
    {
        WALL, WATER, PLANTBASE
    }
    
    public class GridNode : MonoBehaviour, IGridCoord
    {
        [field: SerializeField] public NodeType NodeType { get; private set; }
        
        [SerializeField] protected GridNodeData GridNodeData;
        
        [SerializeField] protected GridNode ParentNode;
        
        protected Dictionary<Adjacent, GridNode> Neighbors = new Dictionary<Adjacent, GridNode>();
        
        [field: SerializeField] public Vector3Int GridPos  { get; private set; }
        [field: SerializeField] public Vector3    WorldPos { get; private set; }
        
        public IGridCoord SetGridPos(Vector3Int _pos)
        {
            GridPos = _pos;
            return this;
        }
        public IGridCoord SetWorldPos(Vector3 _pos)
        {
            WorldPos = _pos;
            return this;
        }

        public GridNode SetGridNodeData(GridNodeData _gridNodeData)
        {
            GridNodeData = _gridNodeData;
            return this;
        }

        public GridNode SetNeighbors()
        {
            Neighbors.Add(Adjacent.N, GridNodeData.AtPos(GridPos + Vector3Int.forward));
            Neighbors.Add(Adjacent.E, GridNodeData.AtPos(GridPos + Vector3Int.right  ));
            Neighbors.Add(Adjacent.W, GridNodeData.AtPos(GridPos + Vector3Int.left   ));
            Neighbors.Add(Adjacent.S, GridNodeData.AtPos(GridPos + Vector3Int.right  ));
            
            Neighbors.Add(Adjacent.NE, GridNodeData.AtPos(GridPos + Vector3Int.forward + Vector3Int.right));
            Neighbors.Add(Adjacent.NW, GridNodeData.AtPos(GridPos + Vector3Int.right   + Vector3Int.left ));
            Neighbors.Add(Adjacent.SE, GridNodeData.AtPos(GridPos + Vector3Int.left    + Vector3Int.right));
            Neighbors.Add(Adjacent.SW, GridNodeData.AtPos(GridPos + Vector3Int.right   + Vector3Int.left ));
            
            return this;
        }

        public bool TryGetNode<T>(Adjacent _adjacent, out T _node) where T : GridNode
        {
            _node = default;

            if (Neighbors.ContainsKey(_adjacent))
            {
                _node = Neighbors[_adjacent] as T;
                
                if (_node != null)
                    return true;
            }
            
            return false;
        }
    }
}
