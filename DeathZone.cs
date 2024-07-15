using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour

{
    private SanityController sanityController;
    // Start is called before the first frame update
    void Start()
    {
        sanityController = FindObjectOfType<SanityController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            sanityController.currentSanity = 0;
            sanityController.UpdateSanityBar();
            Invoke("RestartLevel", 1f);
            
        }
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
