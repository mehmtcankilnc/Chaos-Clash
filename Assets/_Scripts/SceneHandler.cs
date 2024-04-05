using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public Slider progressBar;

    private void Update()
    {
        if (progressBar.value >= 106)
        {
            SceneManager.LoadScene(2);
        }
    }
    public void GoMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitBtn()
    {
        Application.Quit();
    }
}
