using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class MenuController : MonoBehaviour
{
    [Header("Gameplay Settings")]
    [SerializeField] private TextMeshProUGUI controlsText = null;
    [SerializeField] private GameObject keyBinding = null;
    private bool optionsActivated = false;

    [Header("Volume Settings")]
    [SerializeField] private TextMeshProUGUI volumeValueText = null;
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private float defaultVolume = 0.5f;

    [Header("Level to load")]
    public string _gameLevel;
    [SerializeField] private GameObject noSaveGame = null;

    public void NewGameYes()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().SaveData();
        SceneManager.LoadScene(_gameLevel);
    }
    public void LoadGameYes()
    {
        if (PlayerPrefs.GetInt("isSaved") == 1)
        {
            GameObject.FindWithTag("Gamemanager").GetComponent<GameManager>().LoadData();
            SceneManager.LoadScene(_gameLevel);
        }
        else
        {
            noSaveGame.SetActive(true);
        }
    }
    public void QuitBtn()
    {
        Application.Quit();
    }
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        volumeValueText.text = volume.ToString("0.0");
    }
    public void ApplyVolume()
    {
        GameManager.Instance.masterVolume = AudioListener.volume;
    }
    public void GameplayOptions()
    {
        if (!optionsActivated)
        {
            controlsText.text = "Controls <<";
            keyBinding.SetActive(true);
            optionsActivated = true;
        }
        else
        {
            controlsText.text = "Controls >>";
            keyBinding.SetActive(false);
            optionsActivated = false;
        }
    }
    public void ResetBtn(string MenuType)
    {
        if (MenuType == "Audio")
        {
            AudioListener.volume = defaultVolume;
            volumeSlider.value = defaultVolume;
            volumeValueText.text = defaultVolume.ToString("0.0");
            ApplyVolume();
        }
    }
}