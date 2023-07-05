using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PlayerColorUI : MonoBehaviour
    {
        [SerializeField] private GameObject coloringElement;

        public void UpdateUIColor(Material material)
        {
            coloringElement.GetComponent<Image>().color = material.color;
        }
    }
}
