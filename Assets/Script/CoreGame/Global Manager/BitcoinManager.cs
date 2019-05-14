using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Calculate bitcoin value
public class BitcoinManager : MonoBehaviour
{

    //Get other objects
    GameStatManager gameStatManager;

    //Oupput var
    float bitcoinValue;
    Queue<float> bitcoinValueHistory;

    void Start(){
        
        //Get other objects
        gameStatManager = GameObject.Find("GameStatManager").GetComponent<GameStatManager>();

        //Intialize
        bitcoinValueHistory = gameStatManager.GetBitcoinValueHistory();
        bitcoinValue = gameStatManager.GetBitcoinValue();
        //bitcoinValueHistory.Enqueue(bitcoinValue);
        //gameStatManager.SetBitcoinValueHistory(bitcoinValueHistory);
    }

    public void UpdateBitcoinValue(){

        //To GSM (Update history record)
        ShiftRecord();
        gameStatManager.SetBitcoinValueHistory(bitcoinValueHistory);

        float rand = Random.Range(0.9f, 1.1f);
        bitcoinValue *= rand;

        //To GSM
        gameStatManager.SetBitcoinValue(bitcoinValue);
    }

    private void ShiftRecord(){
        if(bitcoinValueHistory.Count >= 20){
            bitcoinValueHistory.Dequeue();
        }
        bitcoinValueHistory.Enqueue(bitcoinValue);
    }
}
