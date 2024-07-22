using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColetarChave : MonoBehaviour
{
    public int chavesColetadas = 0;
    public int totalChaves = 10;
    public string nameTag;

    // Referência ao texto que mostra o número de chaves coletadas
    public TextMeshProUGUI chavesTexto;

    void Update()
    {
        chavesTexto.text = chavesColetadas + "/" + totalChaves;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(nameTag))
        {
            chavesColetadas++;
            Destroy(other.gameObject);
            if (chavesColetadas >= totalChaves)
            {
                LiberarNPCs();
            }
        }
    }

    void LiberarNPCs()
    {
        // Lógica para liberar os NPCs
        Debug.Log("Todos os NPCs foram liberados!");
    }
}
