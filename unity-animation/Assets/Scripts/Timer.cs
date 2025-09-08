using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Simple gameplay timer that displays minutes:seconds.milliseconds
/// and supports start/stop/pause/resume/reset operations.
/// </summary>
public class Timer : MonoBehaviour
{
    /// <summary>Reference to the UI Text (Legacy) used to display the timer.</summary>
    public Text timerText;

    private float elapsed = 0f;
    private bool isRunning = false;

    void OnEnable()
    {
        // Reset display whenever the timer object/canvas is enabled.
        elapsed = 0f;
        isRunning = false;
        UpdateTimerText();
    }

    void Update()
    {
        if (isRunning)
        {
            elapsed += Time.deltaTime;
            UpdateTimerText();
        }
    }

    /// <summary>
    /// Start or resume the timer from its current value.
    /// </summary>
    public void StartTimer()
    {
        isRunning = true;
    }

    /// <summary>
    /// Stop (pause) the timer but keep the elapsed value.
    /// </summary>
    public void StopTimer()
    {
        isRunning = false;
    }

    /// <summary>
    /// PauseTimer alias for StopTimer (keeps compatibility with other scripts).
    /// </summary>
    public void PauseTimer()
    {
        StopTimer();
    }

    /// <summary>
    /// ResumeTimer alias for StartTimer (keeps compatibility with other scripts).
    /// </summary>
    public void ResumeTimer()
    {
        StartTimer();
    }

    /// <summary>
    /// Reset the timer to zero and update the display.
    /// </summary>
    public void ResetTimer()
    {
        elapsed = 0f;
        UpdateTimerText();
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(elapsed / 60f);
        float seconds = elapsed % 60f;
        timerText.text = string.Format("{0}:{1:00.00}", minutes, seconds);
    }
}
