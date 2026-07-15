using UnityEngine;

public class DespawnZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Despawnable") || other.CompareTag("Trap"))
        {
            Destroy(other.gameObject);
        }
    }
}
