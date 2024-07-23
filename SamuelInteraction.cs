
using UnityEngine;
public class SamuelInteraction : MonoBehaviour
{
    public Dialogo dialogoSamuel;
    public GerenciadorDeDialogo gerenciadorDeDialogo;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gerenciadorDeDialogo.IniciarDialogo(dialogoSamuel, true);
        }
    }
}
