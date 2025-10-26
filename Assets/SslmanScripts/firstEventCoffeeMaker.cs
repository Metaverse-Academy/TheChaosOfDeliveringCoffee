using UnityEngine;
using UnityEngine.Rendering;

public class firstEventCoffeeMaker : MonoBehaviour
{
    [SerializeField] private Animator theCoffeeMakerAni;
    [SerializeField] private Volume StartAfraid;
    bool toPlayOnTime = true;
    [SerializeField] private OrderSys OrderSys;
    [SerializeField] private PlayerInteraction playerInteraction;





    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && OrderSys.OrderState == 3 && toPlayOnTime == true)
        {
            toPlayOnTime = false;
            theCoffeeMakerAni.SetTrigger("AfterSecendOrder");

            StartAfraid.enabled = true;
            playerInteraction.PlayerAfraid = true;

        }
    }
    public void TheFearGone()
    {

        theCoffeeMakerAni.SetBool("WeirdThingDone", false);
            StartAfraid.enabled = false;
            playerInteraction.PlayerAfraid = false;



    }
}
