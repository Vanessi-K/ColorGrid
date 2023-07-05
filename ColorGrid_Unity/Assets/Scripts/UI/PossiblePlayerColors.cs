using UnityEngine;

namespace UI
{
    public class PossiblePlayerColors : MonoBehaviour
    {
        [SerializeField] private Material[] playerMaterials;
    
        public Material[] PlayerMaterials => playerMaterials;
    }
}
