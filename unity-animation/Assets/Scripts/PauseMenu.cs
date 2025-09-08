using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;  // Assign PauseCanvas in Inspector
    public Timer timer;             // Drag the Timer GameObject into this slot
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    // Pause the game
    public void Pause()
    {
        pauseCanvas.SetActive(true);
        Time.timeScale = 0f;   // Freeze game
        timer.PauseTimer();    // Pause timer
        isPaused = true;
    }

    // Resume the game
    public void Resume()
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1f;   // Resume game
        timer.ResumeTimer();
        isPaused = false;
    }

    // Reload the current active scene
    public void Restart()
    {
        Time.timeScale = 1f;  // Reset timescale before reload
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Load MainMenu scene
    public void MainMenu()
    {
        Time.timeScale = 1f;  // Reset timescale before switching scenes
        SceneManager.LoadScene("MainMenu");
    }

    // Load Options scene
    public void Options()
    {
        Time.timeScale = 1f;  // Reset timescale before switching scenes
        SceneManager.LoadScene("Options");
    }
}
