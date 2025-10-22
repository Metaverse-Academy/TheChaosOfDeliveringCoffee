using Unity.VisualScripting;
using UnityEngine;

public class WhenPlayerEnterTheOrderZone : MonoBehaviour
{
    [SerializeField] private OrderSys orderSys;



    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            orderSys.setIsPlayerREadTheORder();



        }




    }
}
