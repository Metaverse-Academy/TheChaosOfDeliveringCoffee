using UnityEngine;

public class AudioMusic : MonoBehaviour
{
    bool playOnTime = false;  
      void Start()
    {
        if (OrderSys.instance.OrderState == 4)
        {
            



        }
    }

    // Update is called once per frame
    void Update()
    {
        if (OrderSys.instance.OrderState == 4 && playOnTime == false)
        {
            Debug.Log("stop music");
            gameObject.GetComponent<AudioSource>().enabled = false;
            playOnTime = true;



        }
        
    }
}
