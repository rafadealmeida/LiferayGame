using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniciadorDialogo : MonoBehaviour
{
    [SerializeField]
    private GerenciadorDeDialogo _gerenciador;

    [SerializeField]
    private Dialogo _dialogo;
public void Inicializa()
    {
        if(_dialogo == null)
        {
            return;
        }

        _gerenciador.Inicializa(_dialogo);
    }

public void Log()
{
        Debug.Log("Clicou");
}

}
