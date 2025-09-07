using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles the Options menu functionality.
/// </summary>
public class OptionsMenu : MonoBehaviour
{
    /// <summary>
    /// Loads the previous scene that was open before Options.
    /// </summary>
    public void Back()
    {
        // Load the previous scene in build index order
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex - 1);
    }
}
