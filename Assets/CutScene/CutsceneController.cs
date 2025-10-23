using UnityEngine;
using System.Collections;

public class CutsceneController : MonoBehaviour
{
    [Header("Cameras")]
    public Camera cutsceneCamera;   // assign CutsceneCamera
    public Camera playerCamera;     // assign player's Camera

    [Header("Animation")]
    public AnimationClip cutsceneClip; // assign the animation clip you created

    [Header("Player")]
    public GameObject playerControllerRoot; // optional: root object that contains the player controller (to enable)

    public float extraDelay = 0f; // small buffer if needed

    void Start()
    {
        // Ensure we start in cutscene mode
        if (cutsceneCamera != null) cutsceneCamera.enabled = true;
        if (playerCamera != null) playerCamera.enabled = false;
        if (playerControllerRoot != null) playerControllerRoot.SetActive(false);

        // Start the coroutine to wait for the cutscene clip length
        float wait = (cutsceneClip != null) ? cutsceneClip.length + extraDelay : 0f;
        StartCoroutine(WaitThenEnablePlayer(wait));
    }

    private IEnumerator WaitThenEnablePlayer(float waitSeconds)
    {
        yield return new WaitForSeconds(waitSeconds);

        // Switch cameras
        if (cutsceneCamera != null) cutsceneCamera.enabled = false;
        if (playerCamera != null) playerCamera.enabled = true;

        // Re-enable player controls
        if (playerControllerRoot != null) playerControllerRoot.SetActive(true);
    }
}
