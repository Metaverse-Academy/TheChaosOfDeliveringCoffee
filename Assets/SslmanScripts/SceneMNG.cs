using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMNG : MonoBehaviour
{


    void Start()
    {
        Invoke("endOfGame",10);
    }


    void endOfGame()
    {



        SceneManager.LoadScene("MainMenu");

    }
}
