using UnityEngine;

namespace GameSystem
{
    public class FinalState : GameState
    {
        private Renderer _playerRenderer;
        private Color _finalColor;

        private GameObject _redZone;

        public FinalState(Renderer playerRenderer, Color finalColor, GameObject redZone)
        {
            _playerRenderer = playerRenderer;
            _finalColor = finalColor;
            _redZone = redZone;
        }

        public override void Enter()
        {
            _playerRenderer.material.color = _finalColor;
            _redZone.SetActive(false);
        }

        public override void Exit()
        {
            
        }

        public override void Update()
        {
            
        }
    }
}