using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinController : MonoBehaviour
{
    [SerializeField] private TMP_Text coinText;
    [SerializeField] private int startCoin;
    private static int coin;
    private static bool isBalance;
    private void Awake()
    {
        coin = startCoin;
    }

    public static int GetCoinValue()
    {
        return coin;
    }

    public static void AddCoin(int val) 
    {
        coin += val;
    }

    public static bool SubtractCoin(int val)
    {
        if (val > coin) 
        {
            isBalance = true;
            return false;
        }
        coin -= val;
        return true;
    }

    private void LateUpdate()
    {
        coinText.text = coin.ToString();
        if(isBalance)
        {
            StartCoroutine(ChangeColor());
            isBalance = false;
        }
    }

    private IEnumerator ChangeColor()
    {
        coinText.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        coinText.color = Color.white; 
    }
}
