using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniciadorDialogo : MonoBehaviour
{
    public Dialogo dialogo;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<GerenciadorDeDialogo>().IniciarDialogo(dialogo);
        }
    }
}
