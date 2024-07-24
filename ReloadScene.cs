using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{

    private static ReloadScene instance;

    void Awake()
    {
        // Verifica se uma inst�ncia do GameManager j� existe
        if (instance == null)
        {
            // Se n�o existe, define esta inst�ncia como a �nica
            instance = this;
            DontDestroyOnLoad(gameObject); // N�o destruir o objeto ao carregar uma nova cena
        }
        else
        {
            // Se j� existe, destrua este objeto
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // Verifica se a tecla F5 foi pressionada
        if (Input.GetKeyDown(KeyCode.F5))
        {
            RestartScene();
        }
    }

    void RestartScene()
    {
        // Obt�m o nome da cena atual e recarrega-a
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
