using QuestSystem.Data;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DialogueSequenceSO))]
public class DialogueSequenceSOEditor : UnityEditor.Editor
{
    public override void OnInspectorGUI()
    {
        DialogueSequenceSO dialogueSequenceSO = (DialogueSequenceSO)target;

        if (GUILayout.Button("Add New Dialogue"))
        {
            Dialogue newDialogue = new Dialogue
            {
                id = GenerateID(),
                line = "New dialogue line here",
                speakerIcon = null
            };
            dialogueSequenceSO.Dialogues.Add(newDialogue);
            EditorUtility.SetDirty(dialogueSequenceSO); // Mark as dirty to ensure changes are saved
        }

        if (dialogueSequenceSO.Dialogues != null)
        {
            for (int i = 0; i < dialogueSequenceSO.Dialogues.Count; i++)
            {
                Dialogue dialogue = dialogueSequenceSO.Dialogues[i];

                GUILayout.BeginVertical("box"); // Start of a visual block for each dialogue

                GUILayout.Label("ID: " + dialogue.id);
                dialogue.line = EditorGUILayout.TextField("Dialogue Line", dialogue.line);
                dialogue.speakerIcon = (Sprite)EditorGUILayout.ObjectField("Speaker Icon", dialogue.speakerIcon, typeof(Sprite), false);

                if (GUILayout.Button("Remove Dialogue"))
                {
                    dialogueSequenceSO.Dialogues.RemoveAt(i);
                    EditorUtility.SetDirty(dialogueSequenceSO); // Mark as dirty to ensure changes are saved
                    break; // Exit the loop as the list has changed
                }

                GUILayout.EndVertical(); // End of the visual block
            }
        }

        // Save changes
        if (GUI.changed)
        {
            EditorUtility.SetDirty(dialogueSequenceSO);
        }
        serializedObject.ApplyModifiedProperties();
    }

    private uint GenerateID()
    {
        uint id = (uint)Random.Range(1, int.MaxValue);
        return id;
    }
}
