using deVoid.Utils;
using Input;
using InteractionSystem;
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
            Subscribe();
        }

        public void StartGame()
        {
            EnableMovement(true);
        }

        public void Bind()
        {
            _playerInput.Player.Interactive.performed += _inputHandler.EnterDialogue;
        }

        private void Subscribe()
        {
            Signals.Get<OnEnableMovement>().AddListener(EnableMovement);
        }

        public void Unsubscribe()
        {
            Signals.Get<OnEnableMovement>().RemoveListener(EnableMovement);
        }

        private void EnableMovement(bool IsEnable)
        {
            if (IsEnable)
            {
                _playerInput.Player.Enable();
            }
            else 
            {
                _playerInput.Player.Disable();
            }
        }
    }
}