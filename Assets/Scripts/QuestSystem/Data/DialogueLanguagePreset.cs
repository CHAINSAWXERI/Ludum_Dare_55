using System;
using UnityEngine.Localization;

namespace QuestSystem.Data
{
    [Serializable]
    public struct DialogueLanguagePreset
    {
        public Language language;
        public Locale locale;
        public DialogueSequenceSO dialogueSequenceSo;
    }
}