using Player;
using UnityEngine;

public class DiePlane : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerProperties>().Die();
        }
    }
}
