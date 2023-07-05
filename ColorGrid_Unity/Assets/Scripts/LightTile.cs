using Player;
using UnityEngine;

public class LightTile : MonoBehaviour
{
   [SerializeField] private GameObject lightIndicator;
   private ColorMode _colorMode = ColorMode.Empty;
   
   public ColorMode ColorMode => _colorMode;
   
   private void OnCollisionEnter(Collision other)
   {
      if (other.gameObject.CompareTag("Player"))
      {
         PlayerProperties playerProperties = other.gameObject.GetComponent<PlayerProperties>();
         ChangeColor(playerProperties.PlayerMaterial, playerProperties.ColorMode);
      }
   }

   public void ChangeColor(Material material, ColorMode colorMode)
   {
      lightIndicator.GetComponent<Renderer>().material = material;
      _colorMode = colorMode;
      GameStats.Instance.UpdateTileColorStats();
   }
}
