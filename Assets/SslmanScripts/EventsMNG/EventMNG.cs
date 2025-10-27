using UnityEngine;

public class EventMNG : MonoBehaviour
{
    [SerializeField] OrderSys orderSys;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip SoundCallPlayer;

    //to be sure the event run one time 
    bool IsSoundEvent =false;


    void Update()
    {

        if (orderSys.OrderState == 5 && IsSoundEvent==false)
        {
            Invoke("SoundEvent", 2);
            IsSoundEvent = true;
        }



    }





     void SoundEvent()
    {
        audioSource.PlayOneShot(SoundCallPlayer);

    }
}
