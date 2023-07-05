using UnityEngine;

namespace UFO
{
    public class ColorRaycast : MonoBehaviour
    {
        [SerializeField] private Material emptyMaterial;
        [SerializeField] private ColorMode colorMode;
    
        void Update()
        {
            ChangeColor();   
        }

        void ChangeColor()
        {
            Ray ray = new Ray(transform.position, -transform.up);
            Debug.DrawRay(ray.origin, ray.direction * 90);

            if (Physics.SphereCast(ray, 1f, out RaycastHit hit, 5f))
            {
                if (hit.transform.CompareTag("Tile"))
                {
                    hit.transform.GetComponent<LightTile>().ChangeColor(emptyMaterial, colorMode);
                }
            }
        }
    }

}
