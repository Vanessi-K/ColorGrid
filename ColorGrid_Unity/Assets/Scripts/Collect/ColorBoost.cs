using System.Collections;
using System.Collections.Generic;
using Grid;
using Player;
using UnityEngine;

public class ColorBoost : MonoBehaviour
{
    [SerializeField] private GameObject colorExplosion;
    [SerializeField] private GameObject colorBoostObject;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            colorExplosion.SetActive(true);
            PlayerProperties playerProperties = other.gameObject.GetComponent<PlayerProperties>();
            
            Node currentNode = Grid.Grid.Instance.NodeFromWorldPosition(transform.position);
            List<Node> neighbours = Grid.Grid.Instance.GetNeighbours(currentNode);

            Material material = playerProperties.PlayerMaterial;
            ColorMode colorMode = playerProperties.ColorMode;
            
            foreach (Node node in neighbours)
            {
                node.Tile.GetComponent<LightTile>().ChangeColor(material, colorMode);
            }
            
            colorBoostObject.SetActive(false);

            StartCoroutine(WaitForDestroy());
        }
    }
    
    private IEnumerator WaitForDestroy()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
