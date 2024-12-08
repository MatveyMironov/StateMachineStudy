using GameSystem;
using PlayerSystem;
using UnityEngine;

namespace Core
{
    public class InputListener : MonoBehaviour
    {
        [SerializeField] private KeyCode changeStateKey;
        [SerializeField] private KeyCode attackKey;

        [SerializeField] private KeyCode pauseKey;
        [SerializeField] private KeyCode exitKey;

        private PlayerMovement _playerMovement;
        private CombatStateMachine _combatStateMachine;
        private GameStateMachine _gameStateMacine; 

        private Vector2 _movementInput;

        public bool InputEnabled { get; set; } = false;

        private void Update()
        {
            ListenForPauseInput();
            ListenForExitInput();

            if (!InputEnabled) { return; }

            ListenForMovementInput();
            ListenForAttackInput();
            ListenForChangeStateInput();
        }

        public void Setup(PlayerMovement playerMovement, CombatStateMachine stateMachine, GameStateMachine gameStateMachine)
        {
            _playerMovement = playerMovement;
            _combatStateMachine = stateMachine;
            _gameStateMacine = gameStateMachine;
        }

        private void ListenForPauseInput()
        {
            if (Input.GetKeyDown(pauseKey))
            {
                OnPauseInput();
            }
        }

        private void OnPauseInput()
        {
            _gameStateMacine.TogglePauseState();
        }

        private void ListenForExitInput()
        {
            if (Input.GetKeyDown(exitKey))
            {
                OnExitInput();
            }
        }

        private void OnExitInput()
        {
            _gameStateMacine.EnterFinalState();
        }

        private void ListenForMovementInput()
        {
            _movementInput.x = Input.GetAxis("Horizontal");
            _movementInput.y = Input.GetAxis("Vertical");

            OnMovementInput(_movementInput);
        }

        private void OnMovementInput(Vector2 movementInput)
        {
            _playerMovement?.SetMovementDirection(movementInput);
        }

        private void ListenForAttackInput()
        {
            if (Input.GetKeyDown(attackKey))
            {
                OnAttackInput();
            }
        }

        private void OnAttackInput()
        {
            _combatStateMachine?.Attack();
        }

        private void ListenForChangeStateInput()
        {
            if (Input.GetKeyDown(changeStateKey))
            {
                OnChangeStateInput();
            }
        }

        private void OnChangeStateInput()
        {
            _combatStateMachine?.PerformTransition();
        }
    }
}