using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace QuestSystem.Data
{
    [CreateAssetMenu(menuName = "Dialogue/DialogueSequence", fileName = "DialogueSequence")]
    public class DialogueSequenceSO : ScriptableObject
    {
        [field: SerializeField] public List<Dialogue> Dialogues { get; private set; } // Список усіх діалогів

        // Отримання діалогу за ID
        public Dialogue GetDialogueByID(uint id)
            => Dialogues.FirstOrDefault(d => d.id == id);

        // Отримання наступного діалогу
        public Dialogue GetNextDialogue(uint currentId)
        {
            int index = Dialogues.FindIndex(d => d.id == currentId);
            if (index == -1 || index >= Dialogues.Count - 1) return null;
            return Dialogues[index + 1];
        }
    }
}