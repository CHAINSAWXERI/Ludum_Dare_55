using Input;
using Zenject;

namespace Core
{
    public class Game
    {
        private PlayerInput _playerInput;
        private InputHandler _inputHandler;

        [Inject]
        public Game(PlayerInput playerInput, InputHandler inputHandler)
        {
            _playerInput = playerInput;
            _inputHandler = inputHandler;
        }

        public void StartGame()
        {
            _playerInput.Player.Enable();
        }
    }
}