using System;
using TMPro;
using UnityEngine;

public class OrderSys : MonoBehaviour
{

    [SerializeField] private TMP_Text theOrder;
    [SerializeField] private TMP_Text nameOfTheWorker;


    //--------Start examples

    float RecentTime;
    int ChangeTheText=1;
    void Update()
    {
        RecentTime += Time.deltaTime;
        if (RecentTime > 3)
        {
            RecentTime = 0;


            if (ChangeTheText == 1)
            {
                AddNewOrder("Please i want 1 cup of coffee", "Salman", 1);
                ChangeTheText++;
            }
            else if (ChangeTheText == 2)
            {
                AddNewOrder("I neet extra cup of coffee", "Fares", 1);
                ChangeTheText++;
            }
  else if (ChangeTheText == 3)
            {
                AddNewOrder("Harry up i need my coffee", "Almajd", 1);
                ChangeTheText=1;
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




        }

        else if (stateOfOrder == 2)
        {




        }


    }

}
