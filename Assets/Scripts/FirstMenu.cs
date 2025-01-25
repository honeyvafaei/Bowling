using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstMenu : MonoBehaviour
{

    public void GameStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);

    }

    public void GameQuit()
    {
        Application.Quit();
    }
}

