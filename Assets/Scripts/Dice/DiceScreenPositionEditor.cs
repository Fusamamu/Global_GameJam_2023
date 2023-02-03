#if UNITY_EDITOR
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace GlobalGameJam
{
    [CustomEditor(typeof(DiceScreenPosition))]
    public class DiceScreenPositionEditor : Editor
    {
        private DiceScreenPosition diceScreenPosition;

        private void OnEnable()
        {
            diceScreenPosition = (DiceScreenPosition)target;
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            if (GUILayout.Button("Generate Screen Positions"))
            {
                diceScreenPosition.GenerateDiceScreenPosition(5);
            }

            if (GUILayout.Button("Clear Positions"))
            {
                diceScreenPosition.ClearPositions();
            }
        }
    }
}
#endif
