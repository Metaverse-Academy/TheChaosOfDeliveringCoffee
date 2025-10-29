using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Replace "GameScene" with the actual name of your gameplay scene
        SceneManager.LoadScene("GameDesign week2 Salman");
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
