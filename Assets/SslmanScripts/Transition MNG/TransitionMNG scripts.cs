using UnityEngine;

public class TransitionMNGscripts : MonoBehaviour
{
    [SerializeField] private GameObject Shift2;
        [SerializeField] private GameObject Shift3;
        [SerializeField] private AudioSource WhenShift3;
        [SerializeField] private GameObject Block;
    public static TransitionMNGscripts Instance;

    //for meeting room transition------------
    private int MugsOfTheMettingRoom=0;


    void Awake()
    {
        Instance = this;
    }


    void Update()
    {
        if (MugsOfTheMettingRoom == 5)
        {
            Block.SetActive(false);
            Shift3.SetActive(false);
            WhenShift3.enabled = false;

        }


    }

    public void TransitionToShift2()
    {


        Shift2.SetActive(true);



    }

    public void TakeMug()
    {


        MugsOfTheMettingRoom++;

    }
    public void setBlockActive()
    {
        
            Block.SetActive(true);



    }
}
