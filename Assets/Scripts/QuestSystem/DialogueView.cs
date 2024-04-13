using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace QuestSystem
{
    public class DialogueView : MonoBehaviour
    {
        [SerializeField] private CanvasGroup dialogueObject;
        [SerializeField] private TextMeshProUGUI textDialogue;
        [SerializeField] private Image iconSpeaker;
        [SerializeField] private Button nextDialogueButton;
        

        public void EnableDialogue(DialogueSwitcher currentSwitcher)
        {
            nextDialogueButton.onClick.AddListener(currentSwitcher.ProceedToNextDialogue);
            EnableDialoguePanel();
        }

        private void EnableDialoguePanel(bool isEnable = true)
        {
            dialogueObject.alpha = isEnable ? 1 : 0;
            dialogueObject.interactable = isEnable;
            dialogueObject.blocksRaycasts = isEnable;
        }

        public void UpdateDialogueUI(string dialogueLine, Sprite dialogueSpeakerIcon)
        {
            textDialogue.text = dialogueLine;
            iconSpeaker.sprite = dialogueSpeakerIcon;
        }

        public void HideDialogueUI()
        {
            nextDialogueButton.onClick.RemoveAllListeners();
            EnableDialoguePanel(false);
        }
    }
}