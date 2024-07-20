/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class InteragirComBotao : MonoBehaviour
{
    [SerializeField]
    private JogadorInterage jogadorInterage;

    [SerializeField]
    private UnityEvent botaoApertado;

    private bool podeExecutar;

    void Start()
    {
        if (jogadorInterage == null)
        {
            jogadorInterage = FindObjectOfType<JogadorInterage>();
            if (jogadorInterage == null)
            {
                Debug.LogError("JogadorInterage não encontrado. Certifique-se de que o Player tem o script JogadorInterage.");
            }
        }
    }

    void Update()
    {
        if (podeExecutar && jogadorInterage != null && jogadorInterage.EstaInteragindo)
        {
            botaoApertado.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<JogadorInterage>() != null)
        {
            podeExecutar = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<JogadorInterage>() != null)
        {
            podeExecutar = false;
        }
    }
}
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class InteragirComBotao : MonoBehaviour
{
    [SerializeField]
    private JogadorInterage _jogadorInterage;


    [SerializeField]
    private UnityEvent _botaoApertado;

    private bool _podeExecutar;

    // Update is called once per frame
    void Update()
    {
        if (_podeExecutar)
        {
            if(_jogadorInterage.EstaInteragindo == true)
            {
                _botaoApertado.Invoke();
            }
        }   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _podeExecutar = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _podeExecutar = false;
    }

}