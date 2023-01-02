using UnityEngine;

namespace Player
{
    public class InputHandler
    {
        private static InputHandler _instance;

        public static InputHandler instance
        {
            get
            {
                if (_instance is null)
                {
                    _instance = new InputHandler();
                }

                return _instance;
            }
        }

        public PlayerInput input;
        private InputActions inputActions;

        private InputHandler()
        {
            input = new PlayerInput();
            inputActions = new InputActions();
            inputActions.Enable();
            //Read actions and store them
            inputActions.Player.Look.performed += context => { input.look = context.ReadValue<Vector2>(); };

            inputActions.Player.Look.canceled += _ => { input.look = Vector2.zero; };
            inputActions.Player.Move.canceled += _ => { input.movement = Vector2.zero; };

            inputActions.Player.Move.performed += context => { input.movement = context.ReadValue<Vector2>(); };
            inputActions.Player.Interact.started += _ =>
            {
                input.interact = true;
                input.interactHasBeenUsed = false;
            };
            inputActions.Player.Interact.canceled += _ =>
            {
                input.interact = false;
                input.interactHasBeenUsed = false;
            };
        }
    }


    public struct PlayerInput
    {
        public Vector2 look;
        public Vector2 movement;
        public bool interact;
        public bool interactHasBeenUsed;
    }
}