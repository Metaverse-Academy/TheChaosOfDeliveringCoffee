using UnityEngine;
using System.Collections;

public class CutsceneController : MonoBehaviour
{
    [Header("Cameras")]
    public Camera cutsceneCamera;      // assign CutsceneCamera
    public Camera playerCamera;        // assign player's Camera

    [Header("Player")]
    public GameObject playerControllerRoot; // optional: player controller root object

    [Header("UI")]
    public GameObject crosshair;       // assign your crosshair UI GameObject

    [Header("Cutscene Settings")]
    public AnimationClip cutsceneClip; // assign your Animator clip
    public float extraDelay = 0f;      // optional buffer time

    void Start()
    {
        // Enable cutscene camera, disable player camera & controller
        if (cutsceneCamera != null) cutsceneCamera.enabled = true;
        if (playerCamera != null) playerCamera.enabled = false;
        if (playerControllerRoot != null) playerControllerRoot.SetActive(false);

        // Hide crosshair during cutscene
        if (crosshair != null) crosshair.SetActive(false);

        // Wait for cutscene duration then switch
        float waitTime = (cutsceneClip != null) ? cutsceneClip.length + extraDelay : 0f;
        StartCoroutine(WaitThenEnablePlayer(waitTime));
    }

    private IEnumerator WaitThenEnablePlayer(float waitSeconds)
    {
        yield return new WaitForSeconds(waitSeconds);

        // Switch cameras
        if (cutsceneCamera != null) cutsceneCamera.enabled = false;
        if (playerCamera != null) playerCamera.enabled = true;

        // Enable player controls
        if (playerControllerRoot != null) playerControllerRoot.SetActive(true);

        // Re-enable crosshair
        if (crosshair != null) crosshair.SetActive(true);
    }
}
