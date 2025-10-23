using UnityEngine;

public class CreditsMenu : MonoBehaviour
{
    [Header("References")]
    public CanvasGroup creditsCanvasGroup;  // Drag your CreditsCanvas CanvasGroup here
    public GameObject creditsCanvas;        // Drag the whole CreditsCanvas object here

    [Header("Settings")]
    public float fadeDuration = 0.4f;
    public float scalePop = 1.05f;          // How much it scales up briefly
    public float scaleSpeed = 6f;           // How fast it scales

    private bool isFading = false;
    private bool isVisible = false;         // NEW: track visibility state

    void Start()
    {
        creditsCanvasGroup.alpha = 0;
        creditsCanvas.transform.localScale = Vector3.one;
        creditsCanvas.SetActive(false);
    }

    public void ShowCredits()
    {
        if (isFading || isVisible) return;  // prevent reopening
        isVisible = true;
        creditsCanvas.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(FadeCanvas(0, 1, true));
    }

    public void HideCredits()
    {
        if (isFading || !isVisible) return;  // prevent closing when already hidden
        isVisible = false;
        StopAllCoroutines();
        StartCoroutine(FadeCanvas(1, 0, false));
    }

    private System.Collections.IEnumerator FadeCanvas(float from, float to, bool opening)
    {
        isFading = true;
        float elapsed = 0f;

        Vector3 targetScaleUp = Vector3.one * scalePop;
        Vector3 targetScaleDown = Vector3.one;

        if (opening)
            creditsCanvas.transform.localScale = Vector3.one * 0.95f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / fadeDuration;

            // Fade alpha
            creditsCanvasGroup.alpha = Mathf.Lerp(from, to, t);

            // Scale animation
            if (opening)
            {
                creditsCanvas.transform.localScale = Vector3.Lerp(
                    creditsCanvas.transform.localScale,
                    targetScaleUp,
                    Time.deltaTime * scaleSpeed
                );
            }
            else
            {
                creditsCanvas.transform.localScale = Vector3.Lerp(
                    creditsCanvas.transform.localScale,
                    targetScaleDown * 0.95f,
                    Time.deltaTime * scaleSpeed
                );
            }

            yield return null;
        }

        creditsCanvasGroup.alpha = to;

        if (!opening)
        {
            creditsCanvas.SetActive(false);
            creditsCanvas.transform.localScale = Vector3.one;
        }

        isFading = false;
    }
}
