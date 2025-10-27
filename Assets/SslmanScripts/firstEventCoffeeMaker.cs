using UnityEngine;
using UnityEngine.Rendering;

public class firstEventCoffeeMaker : MonoBehaviour
{
    [SerializeField] private Animator theCoffeeMakerAni;
    [SerializeField] private Volume StartAfraid;
    bool toPlayOnTime = true;
    [SerializeField] private OrderSys OrderSys;
    [SerializeField] private PlayerInteraction playerInteraction;


[SerializeField] private AudioSource coffeeSound;
    [SerializeField] private AudioClip coffeeMachineLoop;
    [SerializeField] private AudioClip coffeeMachineNormal;



    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && OrderSys.OrderState == 3 && toPlayOnTime == true)
        {
            toPlayOnTime = false;
            theCoffeeMakerAni.SetTrigger("AfterSecendOrder");

            StartAfraid.enabled = true;
            playerInteraction.PlayerAfraid = true;

coffeeSound.loop = true;
            coffeeSound.clip = coffeeMachineLoop;
            coffeeSound.Play();


        }
    }
    public void TheFearGone()
    {

        theCoffeeMakerAni.SetBool("WeirdThingDone", false);
            StartAfraid.enabled = false;
            playerInteraction.PlayerAfraid = false;
coffeeSound.clip = coffeeMachineNormal;
        coffeeSound.loop = false;

        coffeeSound.Stop();


    }
}
