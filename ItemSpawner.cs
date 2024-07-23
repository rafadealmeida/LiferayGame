using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab;  // Arraste o prefab do item para esta vari�vel no Inspector
    public Transform spawnPoint;   // Onde o item ser� spawnado

    // Esta fun��o ser� chamada quando a a��o espec�fica acontecer
    public void SpawnItem()
    {
        if (itemPrefab && spawnPoint)
        {
            Instantiate(itemPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
