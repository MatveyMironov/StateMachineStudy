using UnityEngine;

namespace PlayerSystem
{
    public class CombatStateMachine
    {
        private CombatState[] _states;

        private int _currentStateIndex;
        private CombatState _currentState;

        public CombatStateMachine(CombatState[] states)
        {
            _states = states;

            _currentStateIndex = 0;
            _currentState = _states[_currentStateIndex];
        }

        public void Update()
        {
            _currentState?.Update();
        }

        public void Attack()
        {
            _currentState.Attack();
        }

        public void PerformTransition()
        {
            if (_currentStateIndex < _states.Length - 1)
            {
                _currentStateIndex++;
            }
            else
            {
                _currentStateIndex = 0;
            }

            _currentState.Exit();
            _currentState = _states[_currentStateIndex];
            _currentState.Enter();
        }
    }
}