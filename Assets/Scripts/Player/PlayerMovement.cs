using UnityEngine;
using Zenject;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speedMoving; // швидкість руху персонажа
        private Rigidbody2D _rb;
        private PlayerInput _input;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>(); // отримуємо доступ до Rigidbody2D
        }

        [Inject]
        public void Construct(PlayerInput input)
        {
            _input = input; // встановлюємо об'єкт введення
        }

        private void FixedUpdate()
        {
            PlayerMove();
        }

        private void PlayerMove()
        {
            Vector2 dir = _input.Player.Moving.ReadValue<Vector2>(); // читаємо значення вектора руху
            _rb.velocity = dir * speedMoving; // застосовуємо швидкість до вектора руху

            if (dir != Vector2.zero)
            {
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg; // обчислюємо кут на основі вектора руху
                transform.rotation = Quaternion.Euler(0, 0, angle); // повертаємо персонажа на відповідний кут
            }
        }
    }
}