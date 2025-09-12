using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FiniteStateMachineExample))]
public class StateMachineEditor : Editor
{
    public bool showFoldout;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        FiniteStateMachineExample fsm = (FiniteStateMachineExample)target;
        EditorGUILayout.Space(30);
        EditorGUILayout.LabelField("State Machine");
        if (fsm.stateMachine == null)
        {
            return;
        }
        if (fsm.stateMachine.CurrentState != null)
        {
            EditorGUILayout.LabelField("Current State: ", fsm.stateMachine.CurrentState.ToString());
        }
        showFoldout = EditorGUILayout.Foldout(showFoldout,"Available States");
        if (showFoldout)
        {
            if (fsm.stateMachine.DictionaryState != null)
            {
                var keys = fsm.stateMachine.DictionaryState.Keys.ToArray();
                var values = fsm.stateMachine.DictionaryState.Values.ToArray();
                for (int i = 0; i < keys.Length; i++)
                {
                    EditorGUILayout.LabelField(string.Format("{0} :: {1}", keys[i], values[i]));
                }
            }
        }
    }
}
