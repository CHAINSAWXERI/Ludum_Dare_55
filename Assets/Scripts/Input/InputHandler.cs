using InteractionSystem;
using System;
using UnityEngine.InputSystem;
using Zenject;

namespace Input
{
    public class InputHandler
    {
        private InteractComponent _interactComponent;

        [Inject]
        InputHandler(InteractComponent interactComponent) 
        {
            _interactComponent = interactComponent;
        }

        public void EnterDialogue(InputAction.CallbackContext obj)
        {
            _interactComponent.OnInterectTable();
        }
    }
}