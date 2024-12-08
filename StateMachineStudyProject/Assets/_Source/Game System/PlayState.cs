using Core;
using UnityEngine;

namespace GameSystem
{
    public class PlayState : GameState
    {
        private InputListener _inputListener;

        public PlayState(InputListener inputListener)
        {
            _inputListener = inputListener;
        }

        public override void Enter()
        {
            _inputListener.InputEnabled = true;
        }

        public override void Exit()
        {
            _inputListener.InputEnabled = false;
        }

        public override void Update()
        {
            
        }
    }
}