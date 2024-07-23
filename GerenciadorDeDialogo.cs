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
    public GameObject invisibleCollider;
    private bool isSamuelDialogue;
    private bool isDropKey;
    public ItemSpawner itemSpawner;

    void Start()
    {
        sentencas = new Queue<string>();
        locutores = new Queue<string>(); // Inicializa a fila de locutores
    }

    public void IniciarDialogo(Dialogo dialogo, bool isSamuel = false, bool dropKey = false) // Este método inicializa o diálogo
    {
        dialogoBox.SetActive(true);
        isSamuelDialogue = isSamuel;
        isDropKey = dropKey;

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
        if (isSamuelDialogue && invisibleCollider != null) // Modifique esta linha
        {
            Destroy(invisibleCollider);
        }
        if (isDropKey) // Modifique esta linha
        {
            itemSpawner.SpawnItem();
        }
    }

    void Update()
    {
        if (dialogoBox.activeSelf && (Input.GetMouseButtonDown(0))) 
        {
            ProximaSentenca();
        }
 /*       else if (dialogoBox.activeSelf && (Input.GetMouseButtonDown(0) || Input.GetButtonDown("Interage") ))
        {
            ProximaSentenca();
        }*/
    }
}
