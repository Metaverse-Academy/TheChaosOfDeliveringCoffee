using UnityEngine;

public class WorkerTable : MonoBehaviour
{
    [SerializeField] private GameObject MugOfTheWorker;


    public void TheWorkerGetTheCoffee()
    {


        MugOfTheWorker.SetActive(true);


    }
}
