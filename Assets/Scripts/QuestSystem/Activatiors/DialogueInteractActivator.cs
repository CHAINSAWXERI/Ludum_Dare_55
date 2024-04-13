using InteractionSystem;
using UnityEngine;

namespace QuestSystem.Activatiors
{
    public class DialogueInteractActivator : MonoBehaviour, IInteractable
    {
        [SerializeField] private DialogueSwitcher targer;
        public void Interact()
        {
            targer.StartDialogue();
        }
    }
}