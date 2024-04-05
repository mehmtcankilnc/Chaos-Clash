using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] public GameObject progressBar;
    [SerializeField] public GameObject healthBar;
    [SerializeField] public GameObject coinBar;
    [SerializeField] public GameObject minimap;
    [SerializeField] public GameObject pauseMenu;
    private bool isPaused = false;
    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                progressBar.SetActive(false);
                healthBar.SetActive(false);
                coinBar.SetActive(false);
                minimap.SetActive(false);
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
                isPaused = true;
            }
            else
            {
                progressBar.SetActive(true);
                healthBar.SetActive(true);
                coinBar.SetActive(true);
                minimap.SetActive(true);
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
                isPaused = false;
            }
        }
    }
}