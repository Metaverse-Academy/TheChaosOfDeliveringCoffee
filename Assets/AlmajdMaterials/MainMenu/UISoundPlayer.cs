using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UISoundPlayer : MonoBehaviour, IPointerClickHandler
{
    [Header("Sound Settings")]
    public AudioClip clickSound;
    public float volume = 0.6f;

    private static AudioSource audioSource;

    void Awake()
    {
        // Create a single shared AudioSource if not already made
        if (audioSource == null)
        {
            GameObject go = new GameObject("UIAudioSource");
            audioSource = go.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
            DontDestroyOnLoad(go);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (clickSound != null)
            audioSource.PlayOneShot(clickSound, volume);
    }
}
