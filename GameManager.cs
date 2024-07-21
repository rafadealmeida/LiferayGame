using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PhaseNameDisplay phaseNameDisplay;

    public void LoadPhase(string sceneName, string phaseName)
    {
        SceneManager.LoadScene(sceneName);
        // Atualiza o nome da fase antes da cena ser carregada
        phaseNameDisplay.phaseName = phaseName;
    }
}
