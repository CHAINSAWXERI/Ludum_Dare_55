using System;
using UnityEngine;

namespace QuestSystem.Data
{
    [Serializable]
    public class Dialogue
    {
        public uint id; // Унікальний ідентифікатор фрази
        public string line; // Текст фрази
        public Sprite speakerIcon; // Іконка говорящего персонажа
    }
}