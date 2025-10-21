using UnityEngine;

public class LightControl : MonoBehaviour
{
   public GameObject lightGameObject;
   public GameObject SunLightGameObject;
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
        lightGameObject.SetActive(true);
    }
    public void LightDeactivcate()
    {
        lightGameObject.SetActive(false);
    }
    public void LightRandom()
    {
        while (true) 
        {
        int randomNum = Random.Range(0, 2); 

        if (randomNum == 0)
        {
            lightGameObject.SetActive(true);
        }
        else
        {
            lightGameObject.SetActive(false);
        }
        yield return new WaitForSeconds(3f);
        }
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
    public void LightRunningoutofBattery()
    {
        lightGameObject.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        lightGameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);  
        lightGameObject.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        lightGameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        lightGameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        lightGameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
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

}
