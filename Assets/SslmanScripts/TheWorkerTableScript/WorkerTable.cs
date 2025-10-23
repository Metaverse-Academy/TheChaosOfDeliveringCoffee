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
            orderSys.AddNewOrder(1);

        }



    }
    public void ResetIt()
    {
                    TheTableReserved = false;
            MugOfTheWorker.SetActive(false);

    }
}
