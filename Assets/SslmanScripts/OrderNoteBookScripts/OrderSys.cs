using System;
using TMPro;
using UnityEngine;

public class OrderSys : MonoBehaviour
{

    [SerializeField] private TMP_Text theOrder;
    [SerializeField] private TMP_Text nameOfTheWorker;
    [SerializeField] private AudioSource AudioSourceOfOrder;
    [SerializeField] private AudioClip TheAlarmSound;
    public bool IsPlayerREadTheOrder;

    //--------Start examples

    float RecentTime;
    int ChangeTheText = 1;

    void Start()
    {
        AddNewOrder("1 cup of coffee","James",1);



    }

    void Update()
    {


        if (IsPlayerREadTheOrder =false) {


            RecentTime += Time.deltaTime;
            if (RecentTime > 3)
            {
                RecentTime = 0;
                AddNewOrder("","",2);

                Debug.Log("rnrnrnrn");

            } 
            }

//End of the example --------------------


    }






    public void AddNewOrder(String orderDetail, String nameOfTheWorkerMeth, int stateOfOrder)
    {




        if (stateOfOrder == 1)
        {
            theOrder.text = orderDetail;
            nameOfTheWorker.text = nameOfTheWorkerMeth;
            AudioSourceOfOrder.PlayOneShot(TheAlarmSound);
            IsPlayerREadTheOrder = false;


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

}
