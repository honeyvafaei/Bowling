using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
 
    public void GamePlay()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
 
    }

    public void GameStop()
    {

            Application.Quit();  // برای خروج از بازی در زمان اجرا
    }

}
