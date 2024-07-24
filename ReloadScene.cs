using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{

    private static ReloadScene instance;

    void Awake()
    {
        // Verifica se uma instância do GameManager já existe
        if (instance == null)
        {
            // Se não existe, define esta instância como a única
            instance = this;
            DontDestroyOnLoad(gameObject); // Não destruir o objeto ao carregar uma nova cena
        }
        else
        {
            // Se já existe, destrua este objeto
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
        // Obtém o nome da cena atual e recarrega-a
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
