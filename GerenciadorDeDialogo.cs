using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GerenciadorDeDialogo : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _nomeNpc;
    [SerializeField]
    private TextMeshProUGUI _texto;
    [SerializeField]
    private TextMeshProUGUI _btnContinua;

    [SerializeField]
    private GameObject _caixaDeDialogo;

    [SerializeField]
    private float _digitaçãoDelay = 0.025f; 

    private int _contador = 0;
    private Dialogo _dialogoAtual;

    internal void Inicializa(Dialogo dialogo)
    {
        _contador = 0;
        _dialogoAtual = dialogo;
        ProximaFrase();
    }

    private void ProximaFrase()
    {
        if (_dialogoAtual == null)
        {
            Debug.LogWarning("O diálogo atual é nulo");
            return;
        }

        if (_contador >= _dialogoAtual.GetFrases().Length)
        {
            _caixaDeDialogo.SetActive(false);
            _dialogoAtual = null;
            _contador = 0;
            return;
        }

        _nomeNpc.text = _dialogoAtual.GetNomeNpc();
        _caixaDeDialogo.SetActive(true);
        StartCoroutine(EscreverTexto(_dialogoAtual.GetFrases()[_contador].GetFrase()));
        _btnContinua.text = _dialogoAtual.GetFrases()[_contador].GetBotaoContinuar();
    }

    private IEnumerator EscreverTexto(string texto)
    {
        _texto.text = ""; 
        foreach (char letra in texto.ToCharArray())
        {
            _texto.text += letra; 
            yield return new WaitForSeconds(_digitaçãoDelay); 
        }
    }

    public void AvancarDialogo()
    {
        _contador++;
        ProximaFrase();
    }
}
