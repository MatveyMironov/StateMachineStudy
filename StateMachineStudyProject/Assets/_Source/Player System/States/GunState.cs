using UnityEngine;
using WeaponSystem;

namespace PlayerSystem
{
    public class GunState : CombatState
    {
        private Transform _muzzle;
        private Bullet _bulletPrefab;
        private float _bulletSpeed;

        public GunState(Transform muzzle, Bullet bulletPrefab, float bulletSpeed)
        {
            _muzzle = muzzle;
            _bulletPrefab = bulletPrefab;
            _bulletSpeed = bulletSpeed;
        }

        public override void Enter()
        {
            
        }

        public override void Exit()
        {
            
        }

        public override void Update()
        {
            
        }

        public override void Attack()
        {
            Bullet bulletInstance = GameObject.Instantiate(_bulletPrefab, _muzzle.position, _muzzle.rotation);
            bulletInstance.Setup(_bulletSpeed);
        }
    }
}