using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static int _currentCoins = 100;
    public static CoinManager Instance;


    public TextMeshProUGUI _totalCoinText;
    //public TextMeshProUGUI _messageText;

    void Start()
    {
        UpdateTotalCoinText();
    }

    void Update()
    {
        
    }
    void Awake()
    {
        // Ensure there's only one instance of CoinManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        UpdateTotalCoinText();
    }
    public bool BuyItem(int _cost)
    {
        if (_currentCoins > _cost)
        {
            _currentCoins -= _cost;
            UpdateTotalCoinText();
            return true;
        }
        else
        {
            //DisplayMessage("notEnoughCoins");
            return false;
        }
    }
    public void SellItem(int _cost)
    {
        _currentCoins += _cost;
        UpdateTotalCoinText();
    }
    private void UpdateTotalCoinText()
    {
        if (_totalCoinText != null)
        {
            _totalCoinText.text = _currentCoins.ToString();
        }
    }
    //private void DisplayMessage(string key)
    //{
       // if (_messageText != null)
      //  {
        //    _messageText.text = Localizer.GetText(key);
        //}
    //}
}
