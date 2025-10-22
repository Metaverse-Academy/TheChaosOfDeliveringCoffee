using System.Collections;
using UnityEngine;

public class LightControl : MonoBehaviour
{
    public GameObject lightGameObject;
    public GameObject KitchenLightGameObject;
   public Light kitchenLight;
    public GameObject SunLightGameObject;
    private Coroutine flickerCoroutine;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lightGameObject.SetActive(false); 
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            lightGameObject.SetActive(true);
        }
    }

    public void LightActivcate()
    {
        if (flickerCoroutine != null)
        {
            StopCoroutine(flickerCoroutine);
            flickerCoroutine = null;
        }
        lightGameObject.SetActive(true);
    }
    public void LightDeactivcate()
    {
        lightGameObject.SetActive(false);
    }
  

    public IEnumerator LightRunningOutOfBattery()
    {
        var pattern = new[] { 0.3f, 0.3f, 0.2f, 0.2f, 0.1f, 0.1f };
        for (int i = 0; i < pattern.Length; i++)
        {
            lightGameObject.SetActive(i % 2 == 1);
            yield return new WaitForSeconds(pattern[i]);
        }
        lightGameObject.SetActive(false);
    }
   
    public void SunLightOff()
    {
        SunLightGameObject.SetActive(false);
    }
    public void SunLightOn()
    {
        SunLightGameObject.SetActive(true);
    }
    public void KitchenLightControl()
    {
        
    }

}
