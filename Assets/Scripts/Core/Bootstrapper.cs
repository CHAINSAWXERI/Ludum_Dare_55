using UnityEngine;
using Zenject;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [Inject] private Game _game;

        private void Awake()
        {
            
        }

        private void Start()
        {
            _game.StartGame();
        }
    }
}