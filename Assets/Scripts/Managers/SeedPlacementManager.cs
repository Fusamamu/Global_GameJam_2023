using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GlobalGameJam
{
	public class SeedPlacementManager : MonoBehaviour, IService
	{
		public bool IsHoldingSeed => GrabbedSeedNode != null;
		
		[field: SerializeField] public bool IsInit { get; private set; }

		public bool IsEnable;

		[field: SerializeField] public GridNodeData GridNodeData;

		[SerializeField] private SeedNode GrabbedSeedNode;

		[SerializeField] private Vector3 TargetSeedPlacementPos;

		[SerializeField] private GameObject PlacementHolder;
		[SerializeField] private GameObject PlacementHolderPrefab;

		public event Action OnSeedPlaced = delegate { };
        
		public void Initialized()
		{
			if(IsInit) return;
			IsInit = true;

			GridNodeData = ServiceLocator.Instance.Get<GridDataManager>().CurrentGridLevel;

			PlacementHolder = Instantiate(PlacementHolderPrefab, Vector3.zero, Quaternion.identity);
			PlacementHolder.SetActive(false);
		}

		public SeedPlacementManager Enable()
		{
			IsEnable = true;
			return this;
		}

		public SeedPlacementManager Disable()
		{
			IsEnable = false;
			return this;
		}

		public void GrabSeedNode(SeedNode _seedNodePrefab)
		{
			GrabbedSeedNode = Instantiate(_seedNodePrefab, Vector3.zero, Quaternion.identity);
		}

		public void Update()
		{
			if(!IsEnable) return;
			
			if (Mouse.current.leftButton.wasPressedThisFrame)
			{
				if (GrabbedSeedNode != null)
				{
					GridNodeData = ServiceLocator.Instance.Get<GridDataManager>().CurrentGridLevel;
					
					GridNodeData.AddNode(GrabbedSeedNode, TargetSeedPlacementPos.AsVec3Int());

					GrabbedSeedNode
						.SetGridNodeData(GridNodeData)
						.SetGridPos(TargetSeedPlacementPos.AsVec3Int())
						.SetWorldPos(TargetSeedPlacementPos);

					GrabbedSeedNode.Initialized();
					GrabbedSeedNode.StartGrow();
					GrabbedSeedNode = null;

					PlacementHolder.SetActive(false);

					Disable();

					ServiceLocator.Instance.Get<AudioManager>().PlacingSound.Play();
					
					OnSeedPlaced?.Invoke();
				}
			}
		}

		public void FixedUpdate()
		{
			if(!IsEnable) return;
			
			if(GrabbedSeedNode == null) return;
			
			Ray _ray = ServiceLocator.Instance.Get<CameraManager>().MainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());

			if (Physics.Raycast(_ray, out var _hit, Mathf.Infinity))
			{
				if (_hit.collider.TryGetComponent<GridNode>(out var _gridNode))
				{
					if (GrabbedSeedNode != null)
					{
						TargetSeedPlacementPos = _gridNode.WorldPos + Vector3.up;

						GrabbedSeedNode.transform.position = TargetSeedPlacementPos;

						PlacementHolder.SetActive(true);
						PlacementHolder.transform.position = TargetSeedPlacementPos;
					}
				}
				else
				{
					PlacementHolder.SetActive(false);
				}
			}
		}
	}
}
