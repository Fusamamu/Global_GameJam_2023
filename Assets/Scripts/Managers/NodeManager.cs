using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam
{
	public class NodeManager : MonoBehaviour, IService
	{
		[field: SerializeField] public bool IsInit { get; private set; }

		public List<SeedNode> ActiveNodes = new List<SeedNode>();

		public void Initialized()
		{
			if(IsInit) return;
			IsInit = true;
            
		}

		public void AddActiveNode(SeedNode _node)
		{
			ActiveNodes.Add(_node);
		}

		public void ClearActiveNodes()
		{
			ActiveNodes.Clear();
		}

		public bool AllActiveNodesStopGrowing()
		{
			foreach (var _node in ActiveNodes)
			{
				if (_node.Growing)
				{
					return false;
				}
			}

			return true;
		}
		
	}
}
