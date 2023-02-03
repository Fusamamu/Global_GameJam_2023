using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam
{
    public static class Util
    {
        public static Vector3Int AsVec3Int(this Vector3 _vector3)
        {
            return new Vector3Int((int)_vector3.x, (int)_vector3.y, (int)_vector3.z);
        }
    }
}
