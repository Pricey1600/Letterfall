using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void loadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
