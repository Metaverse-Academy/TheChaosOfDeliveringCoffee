using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalCutScene : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (OrderSys.instance.OrderState==9 && other.CompareTag("Player"))
        {



            SceneManager.LoadScene("Scene");

        }
    }
}
