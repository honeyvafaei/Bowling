using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstMenu : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

