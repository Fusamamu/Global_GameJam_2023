#if UNITY_EDITOR
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace GlobalGameJam
{
    [CustomEditor(typeof(DiceManager))]
    public class DiceManagerEditor : Editor
    {
        private DiceManager diceManager;

        private void OnEnable()
        {
            diceManager = (DiceManager)target;
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            if (GUILayout.Button("Spawn Dices"))
            {
                diceManager
                    .SetDiceCount(10)
                    .CreateDices()
                    .StartRollDice();
            }
        }

    }
}
#endif
