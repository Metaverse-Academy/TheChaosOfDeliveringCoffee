using UnityEngine;

public class EventMNG : MonoBehaviour
{

    //sound event---------------------
    [SerializeField] OrderSys orderSys;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip SoundCallPlayer;




    //Light event---------------------
    [SerializeField] GameObject light;
    [SerializeField] private AudioSource[] audios = new AudioSource[0];
    [SerializeField] private AudioSource ForPower;
    [SerializeField] private AudioClip PowerOff;
    [SerializeField] private AudioClip PowerOn;




    //MNGOfficeEvent
    [SerializeField] private Animator MNGOfficeDoor;
    [SerializeField] private Animator MettingOfficeDoor;




    //to be sure the event run one time 
    bool IsSoundEvent = false;
    bool IsLightEvent = false;
    bool IsMNGOfficeEvent = false;


    void Start()
    {
    }
    void Update()
    {

        if (orderSys.OrderState == 5 && IsSoundEvent == false)
        {
            Invoke("SoundEvent", 2);
            IsSoundEvent = true;
        }

        else if (orderSys.OrderState == 6 && IsLightEvent == false)
        {
            IsLightEvent = true;
            LightEvent();



        }
        else if (orderSys.OrderState == 7 && IsMNGOfficeEvent == false)
        {


            MNGEvent();
            IsMNGOfficeEvent = true;

        }


}


        void SoundEvent()
        {
            audioSource.PlayOneShot(SoundCallPlayer);

        }
        void LightEvent()
        {
            light.SetActive(false);
            turnSoundOff();
            ForPower.PlayOneShot(PowerOff);
            Invoke("turnSoundOn", 6);



        }



        void turnSoundOff()
        {

            foreach (var item in audios)
            {
                item.enabled = false;

            }

        }

        void turnSoundOn()
        {
            ForPower.PlayOneShot(PowerOn);

            foreach (var item in audios)
            {
                item.enabled = true;

            }

            light.SetActive(true);

        }
    
    void MNGEvent()
    {
        MNGOfficeDoor.SetTrigger("OpenManagerDoor");
        MettingOfficeDoor.SetTrigger("OpenMettingRoom");


    }
}
