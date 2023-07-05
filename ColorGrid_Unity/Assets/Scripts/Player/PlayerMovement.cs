using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private Animator animator;
        [SerializeField] private Camera playerCamera;
        private bool _isMoving;
        private Vector3 _moveBy;
        private static readonly int Walk = Animator.StringToHash("walk");

        private void Update()
        {
            _isMoving = _moveBy != Vector3.zero;
            ExecuteMovement();
        }

        void OnMove(InputValue input)
        {
            Vector2 inputValue = input.Get<Vector2>();
            _moveBy = new Vector3(inputValue.x, 0, inputValue.y);
        }

        void ExecuteMovement()
        {
            animator.SetBool(Walk, _isMoving);
            if (!_isMoving) return;

            transform.Translate(Vector3.forward * (Time.deltaTime * speed));
            Rotate(_moveBy);
        }

        private void Rotate(Vector3 rotationVector)
        {
            rotationVector = Vector3.Normalize(rotationVector);
            transform.rotation = Quaternion.Euler(0, playerCamera.transform.rotation.eulerAngles.y, 0);
            float rotationY = 90 * rotationVector.x;

            if (rotationVector.z < 0)
            {
                transform.Rotate(0, 180, 0);
                rotationY = -rotationY;
            }

            transform.Rotate(0, rotationY, 0);
        }
    }
}
