using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteracaoDialogo : MonoBehaviour
{
    public Dialogo dialogo;
    private bool jogadorEstaPerto;

    void Update()
    {
        if (jogadorEstaPerto && Input.GetButtonDown("Interage")) // Assumindo que "Interact" � a tecla definida para intera��o
        {
            FindObjectOfType<GerenciadorDeDialogo>().IniciarDialogo(dialogo);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorEstaPerto = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorEstaPerto = false;
        }
    }
}
