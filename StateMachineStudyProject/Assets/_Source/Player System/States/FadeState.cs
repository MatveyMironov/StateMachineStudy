using UnityEngine;

namespace PlayerSystem
{
    public class FadeState : CombatState
    {
        private Renderer _playerRenderer;
        private float _fadedColorAlpha;

        private bool _isFaded;

        private Color _fadedColor;
        private Color _unfadedColor;

        public FadeState(Renderer playerRenderer, float fadedColorAlpha)
        {
            _playerRenderer = playerRenderer;
            _fadedColorAlpha = fadedColorAlpha;

            _unfadedColor = _playerRenderer.material.color;
            _fadedColor = new(_unfadedColor.r, _unfadedColor.g, _unfadedColor.b, _fadedColorAlpha);
        }

        public override void Enter()
        {
            
        }

        public override void Exit()
        {
            Unfade();
        }

        public override void Update()
        {
            
        }

        public override void Attack()
        {
            if (_isFaded)
            {
                Unfade();
            }
            else
            {
                Fade();
            }
        }

        public void Fade()
        {
            _playerRenderer.material.color = _fadedColor;
            _isFaded = true;
        }

        public void Unfade()
        {
            _playerRenderer.material.color = _unfadedColor;
            _isFaded = false;
        }
    }
}