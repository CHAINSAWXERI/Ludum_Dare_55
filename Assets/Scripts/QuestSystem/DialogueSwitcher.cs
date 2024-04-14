using System.Collections;
using deVoid.Utils;
using QuestSystem.Data;
using UnityEngine;
using UnityEngine.Localization.Settings;

namespace QuestSystem
{
    public class DialogueSwitcher : MonoBehaviour
    {
        [SerializeField] private DialogueLanguagePreset[] dialogues;
        [SerializeField] private DialogueView dialogueView;
        [SerializeField] private float waitTime;

        private DialogueSequenceSO _currentLocalizedDialogueSequenceSo;
        private Dialogue _currentDialogue;

        private void Awake()
        {
            var currentLocalization = LocalizationSettings.SelectedLocale;
            foreach (var preset in dialogues)
            {
                if (preset.locale == currentLocalization)
                {
                    _currentLocalizedDialogueSequenceSo = preset.dialogueSequenceSo;
                    break;
                }
            }
        }

        public void StartDialogue()
        {
            _currentDialogue = _currentLocalizedDialogueSequenceSo.Dialogues[0];
            if (_currentDialogue != null)
            {
                dialogueView.EnableDialogue(this);
                dialogueView.UpdateDialogueUI(_currentDialogue.line, _currentDialogue.speakerIcon);
                Signals.Get<OnEnableMovement>().Dispatch(false);
            }
        }

        public void ProceedToNextDialogue()
        {
            Dialogue nextDialogue = _currentLocalizedDialogueSequenceSo.GetNextDialogue(_currentDialogue.id);
            if (nextDialogue != null)
            {
                _currentDialogue = nextDialogue;
                dialogueView.UpdateDialogueUI(_currentDialogue.line, _currentDialogue.speakerIcon);
            }
            else
            {
                EndDialogue();
            }
        }

        private void EndDialogue()
        {
            Signals.Get<OnEnableMovement>().Dispatch(true);
            dialogueView.HideDialogueUI();
            Debug.Log("End dialogue");
            //dialogueView.HideDialogueUI();
            // Тут можна додати інші дії після завершення діалогу
        }
    }
}