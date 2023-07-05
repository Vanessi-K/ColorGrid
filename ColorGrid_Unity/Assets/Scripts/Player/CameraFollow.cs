using UnityEngine;

namespace Player
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;
        private Vector3 _offset;
    
        void Start()
        {
            _offset = transform.position - target.position;
        }

        void LateUpdate()
        {
            transform.position = target.position + _offset;
        }
    }
}
