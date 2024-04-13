using UnityEngine;
using Zenject;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speedMoving;
        private Rigidbody2D _rb;
        private Vector2 _directionMoving;
        private PlayerInput _input;
        private Camera _camera;
        

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _camera = Camera.main;
        }

        [Inject]
        public void SetInput(PlayerInput input)
        {
            _input = input;
        }

        private void FixedUpdate()
        {
            AimPosition();
            PlayerRotate();
            PlayerMove();
        }

        private Vector3 AimPosition()
        {
            Vector3 mousePosition = _input.Player.Rotate.ReadValue<Vector2>();
            return mousePosition;
        }


        private void PlayerRotate()
        {
            var ss = _camera.WorldToScreenPoint(transform.position);
            var aa = AimPosition();
            var direction = aa - ss;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf. Rad2Deg;
            transform. rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }

        private void PlayerMove()
        {
            Vector3 dir = _input.Player.Moving.ReadValue<Vector2>();
            var thisTransform = transform;
            //var currentDirection = thisTransform.up * dir.y + thisTransform.right * dir.x;
            _rb.velocity = dir * speedMoving;
        }
    }
}