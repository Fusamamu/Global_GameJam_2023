using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace GlobalGameJam
{
    public class GridData<T> : MonoBehaviour where T : GridNode
    {
        [field: SerializeField] public T[] Nodes { get; private set; }
        
        [field: SerializeField] public Vector3Int GridSize { get; private set; }

        public int Row    => GridSize.x;
        public int Column => GridSize.z;
        public int Height => GridSize.y;

        public bool UseBrush;
        [SerializeField] private int BrushSize = 1;
        
        //[SerializeField] private GameObject NodeParent;
        [SerializeField] private T NodePrefab;

        public bool HasNodeAt(Vector3 _pos)
        {
            return AtPos(_pos.AsVec3Int()) != null;
        }
        
        public bool TryGetNodeAt(Vector3Int _pos, out T _node)
        {
            _node = AtPos(_pos);

            if (_node != null)
                return true;

            return false;
        }

        public T AtPos(Vector3Int _pos)
        {
            if (IsInBound(_pos))
                return Nodes[_pos.z + Row * (_pos.x + Column * _pos.y)];
            
            return null;
        }

        public GridData<T> SetGridSize(Vector3Int _size)
        {
            GridSize = _size;
            return this;
        }

        public GridData<T> InitGridArray()
        {
            Nodes = new T[Row * Column * Height];
            return this;
        }

        public GridData<T> GenerateNodes()
        {
            for (var _y = 0; _y < Height; _y++)
                for (var _x = 0; _x < Row; _x++)
                    for (var _z = 0; _z < Column; _z++)
                    {
                        // if (!NodeParent)
                        // {
                        //     NodeParent = new GameObject("[Grid Node Parent]")
                        //     {
                        //         transform = { position = Vector3.zero }
                        //     };
                        // }

                        var _targetGridPos  = new Vector3Int(_x, _y, _z);
                        var _targetWorldPos = new Vector3(_x, _y, _z);

                        var _node = Instantiate(NodePrefab, _targetWorldPos, Quaternion.identity, gameObject.transform);

                        _node.name = $"N_{_x}_{_y}_{_x}";

                        _node
                            .SetGridPos (_targetGridPos)
                            .SetWorldPos(_targetWorldPos);

                        AddNode(_node, _targetGridPos);
                    }
            
            return this;
        }

        public GridData<T> GenerateNodesAtLevel(int _level)
        {
            for (var _x = 0; _x < Row; _x++)
            for (var _z = 0; _z < Column; _z++)
            {
                // if (!NodeParent)
                // {
                //     NodeParent = new GameObject("[Grid Node Parent]")
                //     {
                //         transform = { position = Vector3.zero }
                //     };
                // }
                
                var _targetGridPos = new Vector3Int(_x, _level, _z);

                var _node = CreateNodeAt(_targetGridPos);

                AddNode(_node, _targetGridPos);
            }
            
            return this;
        }

        public T CreateNodeAt(Vector3Int _pos)
        {
            var _targetGridPos  = new Vector3Int(_pos.x, _pos.y, _pos.z);
            var _targetWorldPos = new Vector3   (_pos.x, _pos.y, _pos.z);

            var _node = Instantiate(NodePrefab, _targetWorldPos, Quaternion.identity, gameObject.transform);

            _node
                .SetGridPos (_targetGridPos)
                .SetWorldPos(_targetWorldPos);

            return _node;
        }

        public GridData<T> ClearGridData()
        {
            if (Nodes == null) 
                return this;
            
            foreach (var _node in Nodes)
            {
                if (_node == null) continue;
                
                if(Application.isPlaying)
                    Destroy(_node.gameObject);
                else
                    DestroyImmediate(_node.gameObject);
            }
            
            Nodes = null;

            // if (NodeParent)
            // {
            //     if(Application.isPlaying)
            //         Destroy(NodeParent);
            //     else
            //         DestroyImmediate(NodeParent);
            //
            //     NodeParent = null;
            // }
            
            return this;
        }

        public void AddNodesTop(Vector3Int _pos)
        {
            for (int _i = 0; _i < BrushSize; _i++)
            {
                for (int _j = 0; _j < BrushSize; _j++)
                {
                    var _targetPos = _pos + Vector3Int.up + new Vector3Int(_i, 0, _j);

                    if (!IsInBound(_targetPos))
                        continue;
            
                    var _node = CreateNodeAt(_targetPos);

                    AddNode(_node, _targetPos);
                }
            }
        }
        
        public void AddNodeTop(Vector3Int _pos)
        {
            var _targetPos = _pos + Vector3Int.up;
            
            if (!IsInBound(_targetPos))
                return;
            
            var _node = CreateNodeAt(_targetPos);
            
            AddNode(_node, _targetPos);
        }

        public GridData<T> AddNode(T _node, Vector3Int _pos)
        {
            if (!IsInBound(_node))
                return this;
            
            Nodes[_pos.z + Row * (_pos.x + Column * _pos.y)] = _node;

            return this;
        }

        public GridData<T> RemoveNode(T _node)
        {
            if (!IsInBound(_node))
                return this;
            
            var _pos = _node.GridPos;
            
            var _removedNode = Nodes[_pos.z + Row * (_pos.x + Column * _pos.y)];

            if (_removedNode != null)
            {
                if(Application.isPlaying)
                    Destroy(_removedNode.gameObject);
                else
                    DestroyImmediate(_removedNode.gameObject);
            }

            Nodes[_pos.z + Row * (_pos.x + Column * _pos.y)] = null;
            
            return this;
        }

        public bool IsInBound(T _node)
        {
            return IsInBound(_node.GridPos);
        }

        public bool IsInBound(Vector3Int _pos)
        {
            if (_pos.x < 0 || _pos.x > Row     -1 || 
                _pos.z < 0 || _pos.z > Column - 1 || 
                _pos.y < 0 || _pos.y > Height - 1)
                return false;

            return true;
        }
    }
}
