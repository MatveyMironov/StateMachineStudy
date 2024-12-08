using UnityEngine;

namespace PlayerSystem
{
    public abstract class CombatState
    {
        public abstract void Enter();
        public abstract void Exit();
        public abstract void Update();
        public abstract void Attack();
    }
}