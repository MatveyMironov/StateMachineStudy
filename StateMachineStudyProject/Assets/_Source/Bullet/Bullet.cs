using UnityEngine;

namespace WeaponSystem
{
    public class Bullet : MonoBehaviour
    {
        private float _speed;

        private void Update()
        {
            transform.position += transform.up * _speed * Time.deltaTime;
        }

        public void Setup(float speed)
        {
            _speed = speed;
        }
    }
}