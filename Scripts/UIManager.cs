using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenuUI;     // Panel that holds the main menu
    public GameObject instructionUI;  // Panel that holds the instruction text

    public void StartGame()
    {
        // Hide menu UI to reveal the scene
        mainMenuUI.SetActive(false);
    }

    public void ShowInstructions()
    {
        // Show the instructions panel
        instructionUI.SetActive(true);
        mainMenuUI.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");  // Just to confirm in the Editor
    }

    public void BackToMenu()
    {
        instructionUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }
}
