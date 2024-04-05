using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class UpgradeMenuController : MonoBehaviour
{
    [Header("PlayerInfo")]
    [SerializeField] private TextMeshProUGUI coinText = null;
    public int playerCoin;
    public AudioSource coinAudio;
    public GameObject coinWarning;
    private void Start()
    {
        playerCoin = GameManager.Instance.coin;
        currentHealthBar.maxValue = GameManager.Instance.maxHealth;
        currentHealthBar.value = GameManager.Instance.currentHealth;
        damageBar.value = GameManager.Instance.damageLevel;
        speedBar.value = GameManager.Instance.speedLevel;
        maxHealthBar.value = GameManager.Instance.maxHealthLevel;
        maxCoinBar.value = GameManager.Instance.maxCoinLevel;
        damageCostLevel = GameManager.Instance.damageCostLevel;
        speedCostLevel = GameManager.Instance.speedCostLevel;
        maxHealthCostLevel = GameManager.Instance.maxHealthCostLevel;
        maxCoinCostLevel = GameManager.Instance.maxCoinCostLevel;
    }
    private void Update()
    {
        coinText.text = playerCoin.ToString() + " $";

        switch (damageCostLevel)
        {
            case 0:
                damageCostText.text = "50 $";
                damageText.text = "Attack Damage : " + GameManager.Instance.attackDamage.ToString();
                break;
            case 1:
                damageCostText.text = "100 $";
                GameManager.Instance.attackDamage = 10;
                damageText.text = "Attack Damage : " + GameManager.Instance.attackDamage.ToString();
                break;
            case 2:
                damageCostText.text = "150 $";
                GameManager.Instance.attackDamage = 15;
                damageText.text = "Attack Damage : " + GameManager.Instance.attackDamage.ToString();
                break;
            case 3:
                damageCostText.text = "200 $";
                GameManager.Instance.attackDamage = 20;
                damageText.text = "Attack Damage : " + GameManager.Instance.attackDamage.ToString();
                break;
            case 4:
                damageCostText.text = "250 $";
                GameManager.Instance.attackDamage = 25;
                damageText.text = "Attack Damage : " + GameManager.Instance.attackDamage.ToString();
                break;
            case 5:
                damageCostText.text = "Max";
                GameManager.Instance.attackDamage = 30;
                damageText.text = "Attack Damage : " + GameManager.Instance.attackDamage.ToString();
                break;
        }
        switch (speedCostLevel)
        {
            case 0:
                speedCostText.text = "50 $";
                speedText.text = "Move Speed : " + GameManager.Instance.moveSpeed.ToString();
                break;
            case 1:
                speedCostText.text = "100 $";
                GameManager.Instance.moveSpeed = 3.5f;
                speedText.text = "Move Speed : " + GameManager.Instance.moveSpeed.ToString();
                break;
            case 2:
                speedCostText.text = "150 $";
                GameManager.Instance.moveSpeed = 4.0f;
                speedText.text = "Move Speed : " + GameManager.Instance.moveSpeed.ToString();
                break;
            case 3:
                speedCostText.text = "200 $";
                GameManager.Instance.moveSpeed = 4.5f;
                speedText.text = "Move Speed : " + GameManager.Instance.moveSpeed.ToString();
                break;
            case 4:
                speedCostText.text = "250 $";
                GameManager.Instance.moveSpeed = 5.0f;
                speedText.text = "Move Speed : " + GameManager.Instance.moveSpeed.ToString();
                break;
            case 5:
                speedCostText.text = "Max";
                GameManager.Instance.moveSpeed = 5.5f;
                speedText.text = "Move Speed : " + GameManager.Instance.moveSpeed.ToString();
                break;
        }
        switch (maxHealthCostLevel)
        {
            case 0:
                maxHealthCostText.text = "50 $";
                maxHealthText.text = "Max Health : " + GameManager.Instance.maxHealth.ToString();
                break;
            case 1:
                maxHealthCostText.text = "100 $";
                GameManager.Instance.maxHealth = 15;
                maxHealthText.text = "Max Health : " + GameManager.Instance.maxHealth.ToString();
                break;
            case 2:
                maxHealthCostText.text = "150 $";
                GameManager.Instance.maxHealth = 20;
                maxHealthText.text = "Max Health : " + GameManager.Instance.maxHealth.ToString();
                break;
            case 3:
                maxHealthCostText.text = "200 $";
                GameManager.Instance.maxHealth = 25;
                maxHealthText.text = "Max Health : " + GameManager.Instance.maxHealth.ToString();
                break;
            case 4:
                maxHealthCostText.text = "250 $";
                GameManager.Instance.maxHealth = 35;
                maxHealthText.text = "Max Health : " + GameManager.Instance.maxHealth.ToString();
                break;
            case 5:
                maxHealthCostText.text = "Max";
                GameManager.Instance.maxHealth = 50;
                maxHealthText.text = "Max Health : " + GameManager.Instance.maxHealth.ToString();
                break;
        }
        switch (maxCoinCostLevel)
        {
            case 0:
                maxCoinCostText.text = "50 $";
                maxCoinText.text = "Max Coin : " + GameManager.Instance.maxCoin.ToString();
                break;
            case 1:
                maxCoinCostText.text = "100 $";
                GameManager.Instance.maxCoin = 100;
                maxCoinText.text = "Max Coin : " + GameManager.Instance.maxCoin.ToString();
                break;
            case 2:
                maxCoinCostText.text = "150 $";
                GameManager.Instance.maxCoin = 150;
                maxCoinText.text = "Max Coin : " + GameManager.Instance.maxCoin.ToString();
                break;
            case 3:
                maxCoinCostText.text = "200 $";
                GameManager.Instance.maxCoin = 200;
                maxCoinText.text = "Max Coin : " + GameManager.Instance.maxCoin.ToString();
                break;
            case 4:
                maxCoinCostText.text = "250 $";
                GameManager.Instance.maxCoin = 250;
                maxCoinText.text = "Max Coin : " + GameManager.Instance.maxCoin.ToString();
                break;
            case 5:
                maxCoinCostText.text = "Max";
                GameManager.Instance.maxCoin = 300;
                maxCoinText.text = "Max Coin : " + GameManager.Instance.maxCoin.ToString();
                break;
        }
    }

    [Header("Visual Settings")]
    [SerializeField] private Slider damageBar = null;
    [SerializeField] private Slider speedBar = null;
    [SerializeField] private Slider maxHealthBar = null;
    [SerializeField] private Slider maxCoinBar = null;
    [SerializeField] private Slider currentHealthBar = null;
    public void UpgradeBtn(string menuType)
    {
        if (menuType == "Damage")
        {
            switch (damageCostLevel)
            {
                case 0:
                    if (playerCoin >= 50)
                    {
                        coinAudio.Play();
                        damageCostLevel += 1;
                        damageBar.value += 1;
                        playerCoin -= 50;
                        GameManager.Instance.coin = playerCoin;
                        GameManager.Instance.damageLevel = damageBar.value;
                        GameManager.Instance.damageCostLevel = damageCostLevel;
                    }
                    else
                    {
                        StartCoroutine(CoinWarning());
                    }
                    break;
                case 1:
                    if (playerCoin >= 100)
                    {
                        coinAudio.Play();
                        damageCostLevel += 1;
                        damageBar.value += 1;
                        playerCoin -= 100;
                        GameManager.Instance.coin = playerCoin;
                        GameManager.Instance.damageLevel = damageBar.value;
                        GameManager.Instance.damageCostLevel = damageCostLevel;
                    }
                    else
                    {
                        StartCoroutine(CoinWarning());
                    }
                    break;
                case 2:
                    if (playerCoin >= 150)
                    {
                        coinAudio.Play();
                        damageCostLevel += 1;
                        damageBar.value += 1;
                        playerCoin -= 150;
                        GameManager.Instance.coin = playerCoin;
                        GameManager.Instance.damageLevel = damageBar.value;
                        GameManager.Instance.damageCostLevel = damageCostLevel;
                    }
                    else
                    {
                        StartCoroutine(CoinWarning());
                    }
                    break;
                case 3:
                    if (playerCoin >= 200)
                    {
                        coinAudio.Play();
                        damageCostLevel += 1;
                        damageBar.value += 1;
                        playerCoin -= 200;
                        GameManager.Instance.coin = playerCoin;
                        GameManager.Instance.damageLevel = damageBar.value;
                        GameManager.Instance.damageCostLevel = damageCostLevel;
                    }
                    else
                    {
                        StartCoroutine(CoinWarning());
                    }
                    break;
                case 4:
                    if (playerCoin >= 250)
                    {
                        coinAudio.Play();
                        damageCostLevel += 1;
                        damageBar.value += 1;
                        playerCoin += 250;
                        GameManager.Instance.coin = playerCoin;
                        GameManager.Instance.damageLevel = damageBar.value;
                        GameManager.Instance.damageCostLevel = damageCostLevel;
                    }
                    else
                    {
                        StartCoroutine(CoinWarning());
                    }
                    break;
            }
        }
        if (menuType == "Speed")
        {
            switch (speedCostLevel)
            {
                case 0:
                    if (playerCoin >= 50)
                    {
                        coinAudio.Play();
                        speedCostLevel += 1;
                        speedBar.value += 1;
                        playerCoin -= 50;
                        GameManager.Instance.coin = playerCoin;
                        GameManager.Instance.speedLevel = speedBar.value;
                        GameManager.Instance.speedCostLevel = speedCostLevel;
                    }
                    else
                    {
                        StartCoroutine(CoinWarning());
                    }
                    break;
                case 1:
                    if (playerCoin >= 100)
                    {
                        coinAudio.Play();
                        speedCostLevel += 1;
                        speedBar.value += 1;
                        playerCoin -= 100;
                        GameManager.Instance.coin = playerCoin;
                        GameManager.Instance.speedLevel = speedBar.value;
                        GameManager.Instance.speedCostLevel = speedCostLevel;
                    }
                    else
                    {
                        StartCoroutine(CoinWarning());
                    }
                    break;
                case 2:
                    if (playerCoin >= 150)
                    {
                        coinAudio.Play();
                        speedCostLevel += 1;
                        speedBar.value += 1;
                        playerCoin -= 150;
                        GameManager.Instance.coin = playerCoin;
                        GameManager.Instance.speedLevel = speedBar.value;
                        GameManager.Instance.speedCostLevel = speedCostLevel;
                    }
                    else
                    {
                        StartCoroutine(CoinWarning());
                    }
                    break;
                case 3:
                    if (playerCoin >= 200)
                    {
                        coinAudio.Play();
                        speedCostLevel += 1;
                        speedBar.value += 1;
                        playerCoin -= 200;
                        GameManager.Instance.coin = playerCoin;
                        GameManager.Instance.speedLevel = speedBar.value;
                        GameManager.Instance.speedCostLevel = speedCostLevel;
                    }
                    else
                    {
                        StartCoroutine(CoinWarning());
                    }
                    break;
                case 4:
                    if (playerCoin >= 250)
                    {
                        coinAudio.Play();
                        speedCostLevel += 1;
                        speedBar.value += 1;
                        playerCoin -= 250;
                        GameManager.Instance.coin = playerCoin;
                        GameManager.Instance.speedLevel = speedBar.value;
                        GameManager.Instance.speedCostLevel = speedCostLevel;
                    }
                    else
                    {
                        StartCoroutine(CoinWarning());
                    }
                    break;
            }
        }
        if (menuType == "MaxHealth")
        {
            switch (maxHealthCostLevel)
            {
                case 0:
                    if (playerCoin >= 50)
                    {
                        coinAudio.Play();
                        maxHealthCostLevel += 1;
                        maxHealthBar.value += 1;
                        playerCoin -= 50;
                        GameManager.Instance.coin = playerCoin;
                        GameManager.Instance.maxHealthLevel = maxHealthBar.value;
                        GameManager.Instance.maxHealthCostLevel = maxHealthCostLevel;
                    }
                    else
                    {
                        StartCoroutine(CoinWarning());
                    }
                    break;
                case 1:
                    if (playerCoin >= 100)
                    {
                        coinAudio.Play();
                        maxHealthCostLevel += 1;
                        maxHealthBar.value += 1;
                        playerCoin -= 100;
                        GameManager.Instance.coin = playerCoin;
                        GameManager.Instance.maxHealthLevel = maxHealthBar.value;
                        GameManager.Instance.maxHealthCostLevel = maxHealthCostLevel;
                    }
                    else
                    {
                        StartCoroutine(CoinWarning());
                    }
                    break;
                case 2:
                    if (playerCoin >= 150)
                    {
                        coinAudio.Play();
                        maxHealthCostLevel += 1;
                        maxHealthBar.value += 1;
                        playerCoin -= 150;
                        GameManager.Instance.coin = playerCoin;
                        GameManager.Instance.maxHealthLevel = maxHealthBar.value;
                        GameManager.Instance.maxHealthCostLevel = maxHealthCostLevel;
                    }
                    else
                    {
                        StartCoroutine(CoinWarning());
                    }
                    break;
                case 3:
                    if (playerCoin >= 200)
                    {
                        coinAudio.Play();
                        maxHealthCostLevel += 1;
                        maxHealthBar.value += 1;
                        playerCoin -= 200;
                        GameManager.Instance.coin = playerCoin;
                        GameManager.Instance.maxHealthLevel = maxHealthBar.value;
                        GameManager.Instance.maxHealthCostLevel = maxHealthCostLevel;
                    }
                    else
                    {
                        StartCoroutine(CoinWarning());
                    }
                    break;
                case 4:
                    if (playerCoin >= 250)
                    {
                        coinAudio.Play();
                        maxHealthCostLevel += 1;
                        maxHealthBar.value += 1;
                        playerCoin -= 250;
                        GameManager.Instance.coin = playerCoin;
                        GameManager.Instance.maxHealthLevel = maxHealthBar.value;
                        GameManager.Instance.maxHealthCostLevel = maxHealthCostLevel;
                    }
                    else
                    {
                        StartCoroutine(CoinWarning());
                    }
                    break;
            }
        }
        if (menuType == "MaxCoin")
        {
            switch (maxCoinCostLevel)   
            {
                case 0:
                    if (playerCoin >= 50)
                    {
                        coinAudio.Play();
                        maxCoinCostLevel += 1;
                        maxCoinBar.value += 1;
                        playerCoin -= 50;
                        GameManager.Instance.coin = playerCoin;
                        GameManager.Instance.maxCoinLevel = maxCoinBar.value;
                        GameManager.Instance.maxCoinCostLevel = maxCoinCostLevel;
                    }
                    else
                    {
                        StartCoroutine(CoinWarning());
                    }
                    break;
                case 1:
                    if (playerCoin >= 100)
                    {
                        coinAudio.Play();
                        maxCoinCostLevel += 1;
                        maxCoinBar.value += 1;
                        playerCoin -= 100;
                        GameManager.Instance.coin = playerCoin;
                        GameManager.Instance.maxCoinLevel = maxCoinBar.value;
                        GameManager.Instance.maxCoinCostLevel = maxCoinCostLevel;
                    }
                    else
                    {
                        StartCoroutine(CoinWarning());
                    }
                    break;
                case 2:
                    if (playerCoin >= 150)
                    {
                        coinAudio.Play();
                        maxCoinCostLevel += 1;
                        maxCoinBar.value += 1;
                        playerCoin -= 150;
                        GameManager.Instance.coin = playerCoin;
                        GameManager.Instance.maxCoinLevel = maxCoinBar.value;
                        GameManager.Instance.maxCoinCostLevel = maxCoinCostLevel;
                    }
                    else
                    {
                        StartCoroutine(CoinWarning());
                    }
                    break;
                case 3:
                    if (playerCoin >= 200)
                    {
                        coinAudio.Play();
                        maxCoinCostLevel += 1;
                        maxCoinBar.value += 1;
                        playerCoin -= 200;
                        GameManager.Instance.coin = playerCoin;
                        GameManager.Instance.maxCoinLevel = maxCoinBar.value;
                        GameManager.Instance.maxCoinCostLevel = maxCoinCostLevel;
                    }
                    else
                    {
                        StartCoroutine(CoinWarning());
                    }
                    break;
                case 4:
                    if (playerCoin >= 250)
                    {
                        coinAudio.Play();
                        maxCoinCostLevel += 1;
                        maxCoinBar.value += 1;
                        playerCoin -= 250;
                        GameManager.Instance.coin = playerCoin;
                        GameManager.Instance.maxCoinLevel = maxCoinBar.value;
                        GameManager.Instance.maxCoinCostLevel = maxCoinCostLevel;
                    }
                    else
                    {
                        StartCoroutine(CoinWarning());
                    }
                    break;
            }
        }
        if (menuType == "CurrentHealth")
        {
            if (playerCoin >= 100)
            {
                coinAudio.Play();
                currentHealthBar.value = currentHealthBar.maxValue;
                playerCoin -= 100;
                GameManager.Instance.coin = playerCoin;
            }
            else
            {
                StartCoroutine(CoinWarning());
            }
        }
    }
    [Header("Upgrade")]
    [SerializeField] private TextMeshProUGUI damageText = null;
    [SerializeField] private TextMeshProUGUI speedText = null;
    [SerializeField] private TextMeshProUGUI maxHealthText = null;
    [SerializeField] private TextMeshProUGUI maxCoinText = null;

    [Header("Cost")]
    [SerializeField] private TextMeshProUGUI damageCostText = null;
    public int damageCostLevel = 0;
    [SerializeField] private TextMeshProUGUI speedCostText = null;
    public int speedCostLevel = 0;
    [SerializeField] private TextMeshProUGUI maxHealthCostText = null;
    public int maxHealthCostLevel = 0;
    [SerializeField] private TextMeshProUGUI maxCoinCostText = null;
    public int maxCoinCostLevel = 0;

    [Header("SkipLevel")]
    public string _gameLevel;
    public void SkipLevel()
    {
        SceneManager.LoadScene(_gameLevel);
    }
    public IEnumerator CoinWarning()
    {
        coinWarning.SetActive(true);
        yield return new WaitForSeconds(3f);
        coinWarning.SetActive(false);
    }
}