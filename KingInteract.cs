
using UnityEngine;
public class KingInteract : MonoBehaviour
{
    public Dialogo dialogoKing;
    public GerenciadorDeDialogo gerenciadorDeDialogo;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gerenciadorDeDialogo.IniciarDialogo(dialogoKing, false, true);
        }
    }
}
