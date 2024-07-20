using UnityEngine;

public class ItemsMovement : MonoBehaviour
{
    private Vector3 initialPosition;
    public float amplitude = 0.1f; // Amplitude do movimento para cima
    public float frequency = 2f; 

    void Start()
    {
        // Armazena a posição inicial do objeto
        initialPosition = transform.position;
    }

    void Update()
    {
        float newY = initialPosition.y + Mathf.Sin(Time.time * frequency) * amplitude;

        // Atualiza a posição do objeto mantendo X e Z fixos
        transform.position = new Vector3(initialPosition.x, newY, initialPosition.z);
    }
}
