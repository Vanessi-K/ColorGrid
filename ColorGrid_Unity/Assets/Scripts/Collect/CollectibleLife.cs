using UnityEngine;

namespace Collect
{
    public class CollectibleLife : MonoBehaviour
    {
        [SerializeField] private float maxLifetime;
        private float _lifetime;
    
        void Update()
        {
            if(_lifetime >= maxLifetime)
                Destroy(gameObject);
        
            _lifetime += Time.deltaTime;
        }
    }
}
