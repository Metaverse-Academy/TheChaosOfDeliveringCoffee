using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CutsceneController : MonoBehaviour
{
    [Header("Cameras")]
    public Camera cutsceneCamera;
    public Camera playerCamera;

    [Header("Player")]
    public GameObject playerControllerRoot;

    [Header("UI")]
    public GameObject crosshair;

    [Header("Cutscene Settings")]
    public AnimationClip cutsceneClip;
    public float extraDelay = 0f;

    [Header("Cinematic Bars")]
    public RectTransform topBar;
    public RectTransform bottomBar;
    public float slideSpeed = 800f;   // how fast bars slide in
    public float targetHeight = 200f; // how far they slide in
    public float fadeSpeed = 2f;      // how fast they fade out

    private Image topImage;
    private Image bottomImage;

    void Start()
    {
        // Cache images
        topImage = topBar.GetComponent<Image>();
        bottomImage = bottomBar.GetComponent<Image>();

        // Enable cutscene mode
        if (cutsceneCamera != null) cutsceneCamera.enabled = true;
        if (playerCamera != null) playerCamera.enabled = false;
        if (playerControllerRoot != null) playerControllerRoot.SetActive(false);
        if (crosshair != null) crosshair.SetActive(false);

        // Slide bars in
        if (topBar != null && bottomBar != null)
            StartCoroutine(SlideBarsIn());

        // Wait for cutscene to end
        float waitTime = (cutsceneClip != null) ? cutsceneClip.length + extraDelay : 0f;
        StartCoroutine(WaitThenEnablePlayer(waitTime));
    }

    private IEnumerator WaitThenEnablePlayer(float waitSeconds)
    {
        yield return new WaitForSeconds(waitSeconds - 0.5f); // start fading slightly early

        // Fade bars out before switching cameras
        if (topBar != null && bottomBar != null)
            StartCoroutine(FadeBarsOut());

        yield return new WaitForSeconds(0.5f); // let fade finish

        // Switch back to player
        if (cutsceneCamera != null) cutsceneCamera.enabled = false;
        if (playerCamera != null) playerCamera.enabled = true;
        if (playerControllerRoot != null) playerControllerRoot.SetActive(true);
        if (crosshair != null) crosshair.SetActive(true);
    }

    private IEnumerator SlideBarsIn()
    {
        Vector2 topStart = new Vector2(0, 0);
        Vector2 bottomStart = new Vector2(0, 0);
        Vector2 topTarget = new Vector2(0, -targetHeight);
        Vector2 bottomTarget = new Vector2(0, targetHeight);

        float distance = targetHeight;
        float duration = distance / slideSpeed;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.SmoothStep(0f, 1f, elapsed / duration);

            topBar.anchoredPosition = Vector2.Lerp(topStart, topTarget, t);
            bottomBar.anchoredPosition = Vector2.Lerp(bottomStart, bottomTarget, t);

            yield return null;
        }

        topBar.anchoredPosition = topTarget;
        bottomBar.anchoredPosition = bottomTarget;
    }

    private IEnumerator FadeBarsOut()
    {
        float elapsed = 0f;
        Color topColor = topImage.color;
        Color bottomColor = bottomImage.color;

        while (elapsed < 1f)
        {
            elapsed += Time.deltaTime * fadeSpeed;
            float alpha = Mathf.Lerp(1f, 0f, elapsed);

            topColor.a = alpha;
            bottomColor.a = alpha;
            topImage.color = topColor;
            bottomImage.color = bottomColor;

            yield return null;
        }

        // Hide bars completely at end
        topBar.gameObject.SetActive(false);
        bottomBar.gameObject.SetActive(false);
    }
}
