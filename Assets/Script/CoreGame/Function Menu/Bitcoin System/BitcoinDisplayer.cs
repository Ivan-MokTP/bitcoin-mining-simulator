using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BitcoinDisplayer : MonoBehaviour
{

    //Get other objects
    GameStatManager gameStatManager;
    BitcoinManager BitcoinManager;
    Text bitcoinText;
    Text elevatorText;
    Transform historyPanel;

    //Prefab
    public GameObject historyRecord;

    //LocalVar
    int currentDay;

    void Start(){

        //Get other objects
        gameStatManager = GameObject.Find("GameStatManager").GetComponent<GameStatManager>();
        bitcoinText = transform.Find("DisplayContainer/PriceValue").GetComponent<Text>();
        elevatorText = transform.Find("DisplayContainer/ElevatorText").GetComponent<Text>();
        historyPanel = transform.Find("HistoryPanel/ScrollView/Viewport");

        //Initialize
        currentDay = gameStatManager.GetTotalDay();
        UpdateHistory();
    }

    void Update(){

        if (this.gameObject.activeSelf == true){

            //Calculate difference
            float[] records = gameStatManager.GetBitcoinValueHistory().ToArray();
            if (records.Length != 0){
                float newValue = gameStatManager.GetBitcoinValue();
                float oldValue = (float)records[records.Length-1];
            
                float difference = newValue-oldValue;

                bitcoinText.text = newValue.ToString("C2");
                elevatorText.text = difference.ToString("N2")+" ("+((difference/oldValue)*100).ToString("N2")+"%)";
                if (difference >= 0f){
                    elevatorText.color = Color.green;
                } else {
                    elevatorText.color = Color.red;
                } 

                int newDay = gameStatManager.GetTotalDay();
                if (currentDay != newDay){
                    UpdateHistory();
                    currentDay = newDay;
                }
            } else {
                bitcoinText.text = gameStatManager.GetBitcoinValue().ToString("C2");
            }
        }
    }

    void UpdateHistory(){
        float[] records = gameStatManager.GetBitcoinValueHistory().ToArray();
        
        foreach(Transform child in historyPanel){
            GameObject.Destroy(child.gameObject);
        }

        System.Array.Reverse(records);
        for (int i = 0; i < records.Length; i++){
            if (i < 20){
                historyRecord.transform.Find("DayText").GetComponent<Text>().text = (i+1)+" Day(s) ago:";
                historyRecord.transform.Find("HistoryText").GetComponent<Text>().text = records[i].ToString("F2");
                Instantiate(historyRecord, historyPanel);
            }
        }          
    }
}
