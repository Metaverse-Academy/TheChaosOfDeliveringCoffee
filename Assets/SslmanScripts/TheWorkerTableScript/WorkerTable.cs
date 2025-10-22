using UnityEngine;

public class WorkerTable : MonoBehaviour
{


    [SerializeField] private OrderSys orderSys;
    [SerializeField] private GameObject MugOfTheWorker;
    public bool TheTableReserved=false;

    public void TheWorkerGetTheCoffee()
    {
        if (TheTableReserved == false)
        {
                    MugOfTheWorker.SetActive(true);
            TheTableReserved = true;
            orderSys.AddNewOrder("i need more cup ","Michael",1);

        }



    }
}
