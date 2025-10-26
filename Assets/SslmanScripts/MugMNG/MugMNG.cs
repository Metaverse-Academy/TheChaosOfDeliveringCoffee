using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class MugMNG : MonoBehaviour
{

    [SerializeField] private GameObject PlayerMug;

    [SerializeField] private GameObject MugOfTheCoffeeMaker;
    [SerializeField] public GameObject[] EmptyCup = new GameObject[2];
    [SerializeField] private WorkerTable workerTable;
    public bool isThereAvailableCubs = true;
    public int CountOfCupAvalibale = 9;
    void Awake()
    {

        PlayerMug.SetActive(false);

        MugOfTheCoffeeMaker.SetActive(false);

    }
    void Update()
    {

        if (CountOfCupAvalibale == 0)
        {

            isThereAvailableCubs = false;

        }
        else isThereAvailableCubs = true;



    }


    public void activeMugOfPlayer(int state)
    {
        if (state == 1)
        {

            PlayerMug.SetActive(true);
            if (CountOfCupAvalibale == 2)
            {

                workerTable.ResetIt();
            }

        }
        else if (state == 2)
        {

            PlayerMug.SetActive(false);


        }



    }


    public void activeMugOfCoffeeMaker(int state)
    {
        if (state == 1)
        {

            MugOfTheCoffeeMaker.SetActive(true);


        }
        else if (state == 2)
        {

            MugOfTheCoffeeMaker.SetActive(false);


        }



    }
    public void checkIfThereAnyEmptyCup()
    {

        for (int i = 0; i < EmptyCup.Length; i++)
        {

            {

                if (EmptyCup[i].activeInHierarchy == true && CountOfCupAvalibale != 0)

                {

                    EmptyCup[i].SetActive(false);
                    CountOfCupAvalibale--;
                    break;

                }







            }
        }
    }


     public void ResetTheMug()
    {

        for (int i = 0; i < EmptyCup.Length; i++)
        {

            {

                if (EmptyCup[i].activeInHierarchy == false )

                {

                    EmptyCup[i].SetActive(true);
                    CountOfCupAvalibale++;
                    break;

                }







            }
        }
    }
}
