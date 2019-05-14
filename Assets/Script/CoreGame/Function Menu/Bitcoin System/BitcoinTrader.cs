using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//Display bitcoin price
//Manage buy/sell bitcoin
public class BitcoinTrader : MonoBehaviour
{
    //Get other objects
    GameStatManager gameStatManager;
	Text bitcoinIF;
	Text warningText;
    Int64[] badgeCount;

    void Start(){

        //Get other objects
        gameStatManager = GameObject.Find("GameStatManager").GetComponent<GameStatManager>();
		bitcoinIF = transform.Find("TradeInputField/Text").GetComponent<Text>();
		warningText = transform.Find("WarningText").GetComponent<Text>();

    }

    //Buy bitcoin
	public void BuyBitcoin(){
		if (bitcoinIF.text == ""){
			warningText.text = "Please enter the numbr first!!";
            warningText.color = Color.red;
        } else {
            float bitcoinAmount = float.Parse(bitcoinIF.text);
            float bitcoinPrice = bitcoinAmount*gameStatManager.GetBitcoinValue();
            if (gameStatManager.IsEnoughCash(bitcoinPrice)){
                gameStatManager.DeductCash(bitcoinPrice);
                gameStatManager.AddBitcoin(bitcoinAmount);
                warningText.text = "Trade successful";
                warningText.color = Color.green;

                //Add trade count
                badgeCount = gameStatManager.GetBadgeCount();
                badgeCount[1] += 1;
                gameStatManager.SetBadgeCount(badgeCount);

            } else {
                warningText.text = "Not enough cash to buy bitcoin";
                warningText.color = Color.red;
            }
        }
	}

    //Sell bitcoin
    public void SellBitcoin(){
		if (bitcoinIF.text == ""){
			warningText.text = "Please enter the numbr first!!";
        } else {
            float bitcoinAmount = float.Parse(bitcoinIF.text);
            float bitcoinPrice = bitcoinAmount*gameStatManager.GetBitcoinValue();
            if (gameStatManager.IsEnoughBitcoin(bitcoinAmount)){
                gameStatManager.DeductBitcoin(bitcoinAmount);
                gameStatManager.AddCash(bitcoinPrice);
                warningText.text = "Trade successful";
                warningText.color = Color.green;

                //Add trade count
                badgeCount = gameStatManager.GetBadgeCount();
                badgeCount[1] += 1;
                gameStatManager.SetBadgeCount(badgeCount);

            } else {
                warningText.text = "Not enough bitcoin to sell";
                warningText.color = Color.red;
            }
        }
	}
}