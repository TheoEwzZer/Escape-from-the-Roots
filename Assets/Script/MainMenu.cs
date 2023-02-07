using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadLevel()
    {
        SceneManager.LoadScene("SlideMenu");
    }

    public void LoadSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void LoadStory()
    {
        SceneManager.LoadScene("StoryMenu");
    }

    public void Quit(){
        Application.Quit();
    }
}
