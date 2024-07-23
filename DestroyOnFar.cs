using UnityEngine;

public class DestroyOnFar : MonoBehaviour
{
    public Transform player; // Referência ao transform do player
    public float destroyDistance = 10f; // Distância mínima para destruir o objeto

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) >= destroyDistance)
        {
            Destroy(gameObject);
        }
    }
}
