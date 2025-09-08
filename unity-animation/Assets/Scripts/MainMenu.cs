using UnityEngine;
using UnityEngine.SceneManagement;  // Needed to load scenes

/// <summary>
/// Controls the main menu buttons (Level selection, Options, Exit).
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Loads the selected level by number.
    /// </summary>
    /// <param name="level">Level number (1 = Level01, 2 = Level02, 3 = Level03)</param>
    public void LevelSelect(int level)
    {
        string sceneName = "Level0" + level; // Builds "Level01", "Level02", etc.
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// Loads the Options scene.
    /// </summary>
    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    /// <summary>
    /// Quits the game and logs a message in the console.
    /// </summary>
    public void Exit()
    {
        Debug.Log("Exited");
        Application.Quit(); // Works only in a build (not in editor)
    }
}
