using UnityEngine;

public class WorkerTable : MonoBehaviour
{
    [SerializeField] private GameObject MugOfTheWorker;
    public bool TheTableReserved=false;

    public void TheWorkerGetTheCoffee()
    {
        if (TheTableReserved == false)
        {
                    MugOfTheWorker.SetActive(true);
            TheTableReserved = true;


        }



    }
}
