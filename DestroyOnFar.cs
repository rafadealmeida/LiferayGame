using UnityEngine;

public class DestroyOnFar : MonoBehaviour
{
    public Transform player; // Refer�ncia ao transform do player
    public float destroyDistance = 10f; // Dist�ncia m�nima para destruir o objeto

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) >= destroyDistance)
        {
            Destroy(gameObject);
        }
    }
}
