#if UNITY_EDITOR
using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Cecil;
using UnityEditor;
using UnityEngine;

namespace GlobalGameJam
{
    [CustomEditor(typeof(GridNodeData))]
    public class GridNodeDataEditor : Editor
    {
        private GridNodeData gridNodeData;

        private static bool editing;

        private static int boxColorSchemeVersion;
        private static int selectedLevel;

        private static string[] modes =
        {
            "Add", "Remove"
        };

        private static int currentMode;

        private static GameObject pointerPrefab;
        private static GameObject pointer;

        private void OnEnable()
        {
            gridNodeData = (GridNodeData)target;

            if (!pointerPrefab)
            {
                pointerPrefab = Resources.Load<GameObject>("Prefabs/Pointer");
            }

            SceneView.duringSceneGui -= OnScene;
            SceneView.duringSceneGui += OnScene;
        }

        private void OnDisable()
        {
            SceneView.duringSceneGui -= OnScene;
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            EditorGUILayout.Space(20);
            
            EditorGUILayout.LabelField("Edit Grid Data");

            EditorGUI.BeginChangeCheck();
            
            editing               = EditorGUILayout.Toggle("Edit Mode", editing);
            boxColorSchemeVersion = EditorGUILayout.IntField("Box Color Scheme Version : ", boxColorSchemeVersion);
            selectedLevel         = EditorGUILayout.IntField("Selected Level :", selectedLevel);

            if (EditorGUI.EndChangeCheck())
            {
                if (editing)
                {
                    if (!pointer)
                        pointer = Instantiate(pointerPrefab, Vector3.zero, Quaternion.identity);
                }
                else
                {
                    if (pointer)
                    {
                        DestroyImmediate(pointer);
                        pointer = null;
                    }
                }
            }
            
            if (GUILayout.Button("Generate Grid at Selected Level"))
            {
                gridNodeData
                    .ClearGridData()
                    .InitGridArray()
                    .GenerateNodesAtLevel(selectedLevel);
            }
            
            if (GUILayout.Button("Generate Grid"))
            {
                gridNodeData
                    .ClearGridData()
                    .InitGridArray()
                    .GenerateNodes();
            }

            if (GUILayout.Button("Clear Grid"))
            {
                gridNodeData
                    .ClearGridData();
            }
            
            currentMode = GUILayout.Toolbar (currentMode, modes);
        }
        
        private void OnScene(SceneView _sceneView) 
        {
            if(!editing) return;
            
            int _id = GUIUtility.GetControlID(FocusType.Passive);
            HandleUtility.AddDefaultControl(_id);
            
            Ray _ray = HandleUtility.GUIPointToWorldRay (Event.current.mousePosition);
            
            if (Physics.Raycast(_ray.origin, _ray.direction, out RaycastHit _hit, Mathf.Infinity))
            {
                if (_hit.collider.TryGetComponent<GridNode>(out var _node))
                {
                    if (pointer)
                    {
                        pointer.SetActive(true);
                        pointer.transform.position = _node.GridPos;
                    }
                }

                switch (currentMode)
                {
                    case 0:
                        if (Event.current.type == EventType.MouseDown && Event.current.button == 0)
                        {
                            Debug.Log("Click");
                            
                            gridNodeData.AddNodeTop(_node.GridPos);
                             // if (!gridNodeData.UseBrush)
                             // {
                             //     gridNodeData.AddNodeTop(_node.GridPos);
                             //     Debug.Log("Add Node on Top");
                             // }
                             // else
                             //     gridNodeData.AddNodesTop(_node.GridPos);
                        }
                        break;
                    
                    case 1:
                        if (Event.current.type == EventType.MouseDown && Event.current.button == 0)
                        {
                            gridNodeData.RemoveNode(_node);
                        }
                        break;
                }
            }
            else
            {
                if(pointer)
                    pointer.SetActive(false);
            }
        }

        private void OnSceneGUI()
        {
            // if(!editing) return;
            //
            // if (!pointer)
            //     pointer = Instantiate(pointerPrefab, Vector3.zero, Quaternion.identity);
            //
            // var _event = Event.current;
            //
            // Ray _ray = Camera.current.ScreenPointToRay(_event.mousePosition);
            //
            // if (Physics.Raycast(_ray, out var _hit, 1000.0f))
            // {
            //     Debug.Log("Ray");
            //     if (_hit.collider.TryGetComponent<GridNode>(out var _node))
            //     {
            //         if(pointer)
            //             pointer.transform.position = _node.GridPos;
            //     }
            // }
        }
    }
}
#endif
