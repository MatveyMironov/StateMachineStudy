using UnityEngine;

namespace GameSystem
{
    public class PauseState : GameState
    {
        public override void Enter()
        {
            Time.timeScale = 0f;
        }

        public override void Exit()
        {
            Time.timeScale = 1.0f;
        }

        public override void Update()
        {
            
        }
    }
}