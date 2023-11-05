using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
using Ebac.StateMachine;

[CustomEditor(typeof(FSM))]
public class StateMachineEditor : Editor
{
    public bool showFoldout;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        FSM fsm = (FSM)target;

        EditorGUILayout.Space(30);
        EditorGUILayout.LabelField("State Machine");

        if (fsm.StateMachine == null) return;

        if(fsm.StateMachine.CurrentState != null)
        {
            EditorGUILayout.LabelField("Current State", fsm.StateMachine.CurrentState.ToString());
        }

        showFoldout = EditorGUILayout.Foldout(showFoldout, "Avaiable State");

        if(showFoldout && fsm.StateMachine.dictionaryState != null)
        {
            var keys = fsm.StateMachine.dictionaryState.Keys.ToArray();
            var values = fsm.StateMachine.dictionaryState.Values.ToArray();

            for (int i = 0; i < keys.Length; i++)
            {
                EditorGUILayout.LabelField(string.Format("{0} :: {1}", keys[i], values[i]));
            }  
        }
    }
}
#endif