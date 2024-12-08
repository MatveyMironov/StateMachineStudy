using UnityEngine;

namespace PlayerSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float movementSpeed;

        private Rigidbody2D _rigidbody;

        private Vector2 _movementVelocity;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Move(_movementVelocity);
        }

        public void SetMovementDirection(Vector2 direction)
        {
            direction.Normalize();
            _movementVelocity = direction * movementSpeed;
        }

        private void Move(Vector2 movementVelocity)
        {
            _rigidbody.velocity = movementVelocity;
        }
    }
}