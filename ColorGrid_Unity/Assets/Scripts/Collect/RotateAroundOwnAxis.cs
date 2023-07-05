using UnityEngine;

namespace Collect
{
    public class RotateAroundOwnAxis : MonoBehaviour
    {
        [SerializeField] private float rotation = 0.25f;

        void Update()
        {
            transform.Rotate(transform.up, rotation);
        }
    }
}