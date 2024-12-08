using UnityEngine;

namespace PlayerSystem
{
    public class RedZoneState : CombatState
    {
        private GameObject _redZone;

        public RedZoneState(GameObject redZone)
        {
            _redZone = redZone;
        }

        public override void Enter()
        {

        }

        public override void Exit()
        {
            _redZone.SetActive(false);
        }

        public override void Update()
        {

        }

        public override void Attack()
        {
            if (_redZone.activeSelf)
            {
                _redZone.SetActive(false);
            }
            else
            {
                _redZone.SetActive(true);
            }
        }
    }
}