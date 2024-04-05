using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinBar : MonoBehaviour
{
    public Slider coinBar;
    public TextMeshProUGUI coinText;
    private void Start()
    {
        coinBar.maxValue = 2 + GameManager.Instance.maxCoin;
        coinBar.value = 2 + GameManager.Instance.coin;
        coinText.text = GameManager.Instance.coin.ToString() + " $";
    }
    public void GainCoin(int coin)
    {
        if(coinBar.value + coin > GameManager.Instance.maxCoin)
        {
            coinText.text = GameManager.Instance.maxCoin.ToString() + " $";
        }
        coinBar.value += coin;
        coinText.text = GameManager.Instance.coin.ToString() + " $";
    }
}