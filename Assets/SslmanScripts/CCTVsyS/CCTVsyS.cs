using UnityEngine;

public class CCTVsyS : MonoBehaviour
{
    [SerializeField] private Camera CCTVcam;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            CCTVcam.enabled = true;
        }


    }
    void OnTriggerExit(Collider other)
    {
           if (other.CompareTag("Player"))
        {

            CCTVcam.enabled = false;
}
    }
}
