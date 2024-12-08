using UnityEngine;

namespace GameSystem
{
    public class GameStateMachine
    {
        private GameState _playState;
        private GameState _pauseState;
        private GameState _finalState;

        private GameState _currentState;

        public GameStateMachine(GameState playState, GameState pauseState, GameState finalState)
        {
            _playState = playState;
            _pauseState = pauseState;
            _finalState = finalState;
        }

        private bool _canTransit { get { return _currentState != _finalState; } }

        public void EnterPlayState()
        {
            if (!_canTransit) { return; }

            PerformTransition(_playState);
        }

        public void TogglePauseState()
        {
            if (!_canTransit) { return; }

            if (_currentState != _pauseState)
            {
                PerformTransition(_pauseState);
            }
            else
            {
                PerformTransition(_playState);
            }
        }

        public void EnterFinalState()
        {
            if (!_canTransit) { return; }

            PerformTransition(_finalState);
        }

        private void PerformTransition(GameState state)
        {
            if (_currentState == state) { return; }

            _currentState?.Exit();
            _currentState = state;
            _currentState.Enter();
        }
    }
}