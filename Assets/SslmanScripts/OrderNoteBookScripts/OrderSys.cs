using System;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;

public class OrderSys : MonoBehaviour
{
    [SerializeField] private PlayerInteraction playerInteraction;
    [SerializeField] private TMP_Text theOrder;
    [SerializeField] private TMP_Text nameOfTheWorker;
    [SerializeField] private AudioSource AudioSourceOfOrder;
    [SerializeField] private AudioClip TheAlarmSound;
    public bool IsPlayerREadTheOrder;
    [SerializeField] private String[] orderDetail = new string[8];
    [SerializeField] private String[] nameOfTheWorkerMeth = new string[8];
        [SerializeField] private BoxCollider[] OffceCollider = new BoxCollider[8];


    bool toPlayOnTime=true;
    public int OrderState = 0;

    float RecentTime;
    int ChangeTheText = 1;

    void Start()
    {
        AddNewOrder(1);
            activeOnlyTheOne(0);



    }

    void Update()
    {
        if (OrderState == 4 && toPlayOnTime == true)
        {
            playerInteraction.isMachineBroken = true;
            toPlayOnTime = false;

        }
        if(OrderState == 5 )
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Credits");
        }

        if (IsPlayerREadTheOrder ==false) {


            RecentTime += Time.deltaTime;
            if (RecentTime > 8)
            {
                RecentTime = 0;
                AddNewOrder(2);


            } 
            }


    }






    public void AddNewOrder( int stateOfOrder)
    {




        if (stateOfOrder == 1)
        {
            theOrder.text = orderDetail[OrderState];
            nameOfTheWorker.text = nameOfTheWorkerMeth[OrderState];
            AudioSourceOfOrder.PlayOneShot(TheAlarmSound);
            IsPlayerREadTheOrder = false;
            activeOnlyTheOne(OrderState);
            OrderState++;

        }

        else if (stateOfOrder == 2)
        {

            AudioSourceOfOrder.PlayOneShot(TheAlarmSound);


        }


    }

    public void setIsPlayerREadTheORder()
    {

        IsPlayerREadTheOrder = true;



    }
    void activeOnlyTheOne(int x)
    {
        for (int i = 0; i <= 7; i++)
        {

            OffceCollider[i].enabled = false;
        }
        OffceCollider[x].enabled = true;



    }
}
