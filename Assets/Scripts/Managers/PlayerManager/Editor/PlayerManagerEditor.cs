using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PlayerManager))]
public class PlayerManagerEditor : Editor
{
    public bool showFoldout;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        PlayerManager playerManager = (PlayerManager)target;
        EditorGUILayout.Space(30);
        EditorGUILayout.LabelField("State Machine");
        if (playerManager.stateMachine == null)
        {
            return;
        }
        if (playerManager.stateMachine.CurrentState != null)
        {
            EditorGUILayout.LabelField("Current State: ", playerManager.stateMachine.CurrentState.ToString());
        }
        showFoldout = EditorGUILayout.Foldout(showFoldout,"Available States");
        if (showFoldout)
        {
            if (playerManager.stateMachine.DictionaryState != null)
            {
                var keys = playerManager.stateMachine.DictionaryState.Keys.ToArray();
                var values = playerManager.stateMachine.DictionaryState.Values.ToArray();
                for (int i = 0; i < keys.Length; i++)
                {
                    EditorGUILayout.LabelField(string.Format("{0} :: {1}", keys[i], values[i]));
                }
            }
        }
    }
}
