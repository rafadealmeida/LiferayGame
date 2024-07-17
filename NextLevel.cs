using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public string nextSceneName;
    //private SanityController sanityController;
    void Start()
    {
        
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextSceneName);
            //sanityController.currentSanity = currentSanity;
            // UpdateSanityBar();
        }
    }
}
