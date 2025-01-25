using UnityEngine;
using UnityEngine.SceneManagement;

public class inGame_Menu : MonoBehaviour
{
    public GameObject Menu;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Menu.activeSelf)
            {
                Menu.SetActive(false);
            }
            else
            {
                Menu.SetActive(true);
            }
        }
    }

    public void GameReStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void BackToGameMenu()
    {
        SceneManager.LoadScene(0);
    }

}
