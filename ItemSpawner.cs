using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab;  // Arraste o prefab do item para esta variável no Inspector
    public Transform spawnPoint;   // Onde o item será spawnado

    // Esta função será chamada quando a ação específica acontecer
    public void SpawnItem()
    {
        if (itemPrefab && spawnPoint)
        {
            Instantiate(itemPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
