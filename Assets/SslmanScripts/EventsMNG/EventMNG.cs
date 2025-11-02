using System;
using UnityEngine;

public class EventMNG : MonoBehaviour
{

    //sound event---------------------
    [SerializeField] OrderSys orderSys;
    [SerializeField] AudioSource audioSource;
        [SerializeField] AudioSource audioSourceMusic;

    [SerializeField] AudioClip SoundCallPlayer;




    //Light event---------------------
    [SerializeField] GameObject light;
    [SerializeField] private AudioSource[] audios = new AudioSource[0];
    [SerializeField] private AudioSource ForPower;
    [SerializeField] private AudioClip PowerOff;
    [SerializeField] private AudioClip PowerOn;




    //MNGOffice Event-----------------
    [SerializeField] private Animator MNGOfficeDoor;
    [SerializeField] private Animator MettingOfficeDoor;


    //WidnowKnock Event-----------------
    [SerializeField] private Animator AppearAndDisapper;
    [SerializeField] private Animator HankKnocks;
    [SerializeField] private AudioSource audioSourceForKnock;
    [SerializeField] private AudioClip Knocks;
    [SerializeField] private AudioClip JumpScare;
                float RecentTimeForWindowGuy;

    bool IsWindowGuyAppear = false;
    [SerializeField] private GameObject TheWindowGuy;

    public static EventMNG instance;


    //RedLight Event-----------------
    [SerializeField] GameObject Redlight;
        [SerializeField] private AudioSource RedAlert;

    //RedLight Event-----------------
    [SerializeField] private GameObject WallThatWillDisappear;
    [SerializeField] private GameObject WallThatWillDisappear2;
    [SerializeField] private GameObject WallThatWillAppear;


    [SerializeField] private AudioSource Audioss1;
    [SerializeField] private AudioSource Audioss2;
    [SerializeField] private AudioSource Audioss3;
    [SerializeField] private AudioSource Audioss4;
    [SerializeField] private AudioSource Audioss5;



    //to be sure the event run one time 
    bool IsSoundEvent = false;
    bool IsLightEvent = false;
    bool IsMNGOfficeEvent = false;
    bool IsWindowKnockEvent = false;
        bool IsRedLightEvent=false;
    void Awake()
    {
        instance = this;
    }

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
            Invoke("MNGEvent", 10);



        }
        else if (orderSys.OrderState == 7 && IsMNGOfficeEvent == false)
        {

            MettingOfficeDoor.SetTrigger("OpenMettingRoom");
            TransitionMNGscripts.Instance.setBlockActive();


            IsMNGOfficeEvent = true;

        }

        else if (orderSys.OrderState == 8 && IsWindowKnockEvent == false)
        {
            TheWindowGuy.SetActive(true);
            WindowEventAppear();
            IsWindowKnockEvent = true;

        }

        else if (orderSys.OrderState == 9 && IsRedLightEvent ==false)
        {
            IsRedLightEvent = true;
            RedLightEvent();
        }

        if (IsWindowGuyAppear == true)
        {
            Debug.Log(RecentTimeForWindowGuy);
           if( CameraRangeDetecetSys.instance != null)
            Debug.Log("sssss");
           {
                     if (CameraRangeDetecetSys.instance.IsTargetvisible == true)
                     {
                       audioSourceForKnock.PlayOneShot(JumpScare);
                      Invoke("WindowEventDisAppear", 0.5f);
                          IsWindowGuyAppear = false;

                         }
        }

        if(CameraRangeDetecetSys.instance.IsTargetvisible == false)
        {
                RecentTimeForWindowGuy += Time.deltaTime;
            
            if (RecentTimeForWindowGuy > 2)
            {
                knockTheWindow();
                RecentTimeForWindowGuy = 0;

            }


        }
              
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


    }


    void WindowEventAppear()
    {
        AppearAndDisapper.SetTrigger("StartEvent");
        IsWindowGuyAppear = true;
        Invoke("knockTheWindow",1);

    }

 void WindowEventDisAppear()
    {
        AppearAndDisapper.SetTrigger("EndEvent");
        Invoke("DisappearWindowGuy",1.5f);
    }

    void knockTheWindow()
    {

        HankKnocks.SetTrigger("StartKnockEvent");
        audioSourceForKnock.PlayOneShot(Knocks);

    }
    void DisappearWindowGuy()
    {


        TheWindowGuy.SetActive(false);

    }


    void RedLightEvent()
    {

        light.SetActive(false);
        Redlight.SetActive(true);
        RedAlert.enabled = true;
        Invoke("RedLightEventOff",7);

    }

    void RedLightEventOff()
    {

        light.SetActive(true);
        Redlight.SetActive(false);
        RedAlert.enabled = false;

    }

    public void finalEvent()
    {

        WallThatWillDisappear.SetActive(false);
        WallThatWillDisappear2.SetActive(false);
        WallThatWillAppear.SetActive(true);

        Audioss1.enabled = true;
        Audioss2.enabled = true;
        Audioss3.enabled = true;
        Audioss4.enabled = true;
        Audioss5.enabled = true;

        
    }

}
