using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    private Animator animator;
    public Camera mainCamera;
    public GameObject timerCanvas;
    public PlayerController playerController;

    void Start()
    {
        animator = GetComponent<Animator>();

        // Disable player and timer until cutscene is over
        if (playerController != null)
            playerController.enabled = false;

        if (timerCanvas != null)
            timerCanvas.SetActive(false);

        if (mainCamera != null)
            mainCamera.enabled = false;
    }

    void Update()
    {
        // Wait until animation finishes
        if (animator != null && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            EndCutscene();
        }
    }

    void EndCutscene()
    {
        // Enable main camera
        if (mainCamera != null)
            mainCamera.enabled = true;

        // Enable player movement
        if (playerController != null)
            playerController.enabled = true;

        // ✅ Show Timer UI but do NOT start it yet
        if (timerCanvas != null)
            timerCanvas.SetActive(true);

        // Disable this script so it doesn’t keep running
        this.enabled = false;
    }
}
