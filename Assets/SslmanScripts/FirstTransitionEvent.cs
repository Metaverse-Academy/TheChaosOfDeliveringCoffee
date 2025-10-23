using UnityEngine;

public class FirstTransitionEvent : MonoBehaviour
{
    [SerializeField] private PlayerInteraction playerInteraction;


    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player")&&playerInteraction.isMachineBroken==true)
        {



        }



    }
}
