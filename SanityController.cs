using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityController : MonoBehaviour
{
    public Image sanityBar;
    public Sprite[] sanitySprites;
    public int currentSanity;
    private int maxSanity = 100;

    void Start()
    {
        currentSanity = maxSanity;
        UpdateSanityBar();
    }

    public void TakeDamage(int damage)
    {
        currentSanity -= damage;
        if (currentSanity < 0)
        {
            currentSanity = 0;
        }
        UpdateSanityBar();
    }
    public void RecoverSanity(int amount)
    {
        currentSanity += amount;
        if (currentSanity > maxSanity)
        {
            currentSanity = maxSanity;
        }
        UpdateSanityBar();
    }

    public void UpdateSanityBar()
    {
        if (sanitySprites.Length == 0) return; 

        int sanityIndex = Mathf.FloorToInt((currentSanity / (float)maxSanity) * (sanitySprites.Length - 1));
        sanityBar.sprite = sanitySprites[sanityIndex];
    }

    
    private void OnValidate()
    {
        UpdateSanityBar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
