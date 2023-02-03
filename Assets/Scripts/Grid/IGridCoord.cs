using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam
{
    public interface IGridCoord
    {
        public Vector3Int GridPos  { get; }
        public Vector3    WorldPos { get; }

        public IGridCoord SetGridPos (Vector3Int _pos);
        public IGridCoord SetWorldPos(Vector3 _pos);
    }
}
