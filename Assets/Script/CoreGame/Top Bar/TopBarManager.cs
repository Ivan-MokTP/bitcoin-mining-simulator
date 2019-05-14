using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Update cash display
// Update bitcoin display
// Set profile name
public class TopBarManager : MonoBehaviour
{

    //Get other objects
    private GameStatManager gameStatManager;

    //Local var
    private Text profileName;
    private Text cash;
    private Text bitcoin;

    void Start(){

        //Get other objects
        gameStatManager = GameObject.Find("GameStatManager").GetComponent<GameStatManager>();
        profileName = transform.Find("ProfileName").GetComponent<Text>();
        cash = transform.Find("CashAmount").GetComponent<Text>();
        bitcoin = transform.Find("BitcoinAmount").GetComponent<Text>();

        //Set profile name
        profileName.text = gameStatManager.GetProfileName();

        //Initialize
        cash.text = gameStatManager.GetCash().ToString("N2");
        bitcoin.text = gameStatManager.GetBitcoin().ToString();
    }

    public void UpdateCash(float cash){
        this.cash.text = "$ "+cash.ToString("N2");
    }

    public void UpdateBitcoin(float bitcoin){
        this.bitcoin.text = "₿ "+bitcoin.ToString();
    }
}
