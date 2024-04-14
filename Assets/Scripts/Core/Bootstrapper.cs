using UnityEngine;
using Zenject;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [Inject] private Game _game;

        private void Awake()
        {
            _game.Bind();
        }

        private void Start()
        {
            _game.StartGame();
        }

        private void OnDestroy()
        {
            _game.Unsubscribe();
        }
    }
}