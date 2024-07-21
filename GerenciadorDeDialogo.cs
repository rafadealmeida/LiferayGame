using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GerenciadorDeDialogo : MonoBehaviour
{
    public TMP_Text nomeText;
    public TMP_Text dialogoText;
    public GameObject dialogoBox;
    private Queue<string> sentencas;
    private Queue<string> locutores; // Adicionando fila de locutores

    void Start()
    {
        sentencas = new Queue<string>();
        locutores = new Queue<string>(); // Inicializa a fila de locutores
    }

    public void IniciarDialogo(Dialogo dialogo) // Este método inicializa o diálogo
    {
        dialogoBox.SetActive(true);

        sentencas.Clear();
        locutores.Clear(); // Limpa a fila de locutores

        foreach (string locutor in dialogo.locutores)
        {
            locutores.Enqueue(locutor); // Adiciona cada locutor na fila
        }

        foreach (string sentenca in dialogo.sentencas)
        {
            sentencas.Enqueue(sentenca);
        }

        ProximaSentenca();
    }

    public void ProximaSentenca()
    {
        if (sentencas.Count == 0)
        {
            FimDeDialogo();
            return;
        }

        string sentenca = sentencas.Dequeue();
        string locutor = locutores.Dequeue(); // Pega o locutor correspondente

        nomeText.text = locutor; // Exibe o nome do locutor
        StopAllCoroutines();
        StartCoroutine(DigitarSentenca(sentenca));
    }

    IEnumerator DigitarSentenca(string sentenca)
    {
        dialogoText.text = "";
        foreach (char letra in sentenca.ToCharArray())
        {
            dialogoText.text += letra;
            yield return null;
        }
    }

    void FimDeDialogo()
    {
        dialogoBox.SetActive(false);
        Debug.Log("Fim do diálogo.");
    }

    void Update()
    {
        if (dialogoBox.activeSelf && Input.GetMouseButtonDown(0)) // Avança ao clicar na caixa de diálogo
        {
            ProximaSentenca();
        }
    }
}
