using System;
using TMPro;
using UnityEngine;

public class OrderSys : MonoBehaviour
{

    [SerializeField] private TMP_Text theOrder;
    [SerializeField] private TMP_Text nameOfTheWorker;

    void Start()
    {

        AddNewOrder("please i want 1 cup of coffee" , "salman",1);


    }




    public void AddNewOrder(String orderDetail, String nameOfTheWorkerMeth, int stateOfOrder)
    {




        if (stateOfOrder == 1)
        {
            theOrder.text = orderDetail;
            nameOfTheWorker.text = nameOfTheWorkerMeth;




        }

        else if (stateOfOrder == 2)
        {




        }


    }

}
