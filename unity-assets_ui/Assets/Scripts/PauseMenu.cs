using UnityEngine;

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

    // Prototype: public void Pause()
    public void Pause()
    {
        pauseCanvas.SetActive(true);
        Time.timeScale = 0f;   // Pause all physics/animations
        timer.PauseTimer();    // Stop the timer
        isPaused = true;
    }

    // Prototype: public void Resume()
    public void Resume()
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1f;   // Resume game
        timer.ResumeTimer();   // Resume the timer
        isPaused = false;
    }
}
