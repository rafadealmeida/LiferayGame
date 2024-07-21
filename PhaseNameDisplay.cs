using UnityEngine;
using TMPro;
using System.Collections;

public class PhaseNameDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI phaseText; // Refer�ncia ao componente TextMeshPro
    [SerializeField] private float fadeDuration = 1f;   // Dura��o do fade-in e fade-out
    [SerializeField] private float displayDuration = 5f; // Dura��o que o texto fica vis�vel
    public string phaseName;                            // Nome da fase

    private void Start()
    {
        if (phaseText != null)
        {
            phaseText.text = phaseName;  // Define o texto como o nome da fase
            phaseText.alpha = 0;         // Inicialmente invis�vel
            StartCoroutine(FadeInAndOut());
        }
    }

    private IEnumerator FadeInAndOut()
    {
        // Fade In
        yield return StartCoroutine(FadeTextToFullAlpha());
        // Wait for display duration
        yield return new WaitForSeconds(displayDuration);
        // Fade Out
        yield return StartCoroutine(FadeTextToZeroAlpha());
    }

    private IEnumerator FadeTextToFullAlpha()
    {
        float timer = 0;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            phaseText.alpha = Mathf.Lerp(0, 1, timer / fadeDuration);
            yield return null;
        }
        phaseText.alpha = 1;
    }

    private IEnumerator FadeTextToZeroAlpha()
    {
        float timer = 0;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            phaseText.alpha = Mathf.Lerp(1, 0, timer / fadeDuration);
            yield return null;
        }
        phaseText.alpha = 0;
    }
}
