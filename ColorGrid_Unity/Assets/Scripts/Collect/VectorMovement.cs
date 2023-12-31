using UnityEngine;

namespace Collect
{
    public class VectorMovement : MonoBehaviour
    {
        [SerializeField] private Vector3 movementDirection;
        [SerializeField] private float movementTime;
        private Vector3 _startPosition;
        private Vector3 _targetPosition;
        private float _passedMovementTime;

        void Start()
        {
            _startPosition = transform.position;
            _targetPosition = _startPosition + movementDirection;
        }

        void Update()
        {
            if (_passedMovementTime >= movementTime)
            {
                ChangeMovementDirection();
            }

            transform.position = Vector3.Lerp(_startPosition, _targetPosition, _passedMovementTime / movementTime);
            _passedMovementTime += Time.deltaTime;
        }

        void ChangeMovementDirection()
        {
            (_startPosition, _targetPosition) = (_targetPosition, _startPosition);
            _passedMovementTime = 0;
        }
    }
}