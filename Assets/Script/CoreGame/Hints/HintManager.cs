using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintManager : MonoBehaviour
{

    GameObject hintPanel;
    Text hintText;
    // Start is called before the first frame update
    void Start()
    {
        hintPanel = transform.Find("HintFilter").gameObject;
        hintText = transform.Find("HintFilter/HintPanel/HintText").GetComponent<Text>();
        hintPanel.SetActive(false);
    }

    // Update is called once per frame
    public void OnClose(){
        hintPanel.SetActive(false);
        hintText.text = "";
    }

    public void DateHint(){
        hintPanel.SetActive(true);
        hintText.text = "- The passing time is 10 minutes for 1 tick.\n- For each 10 minutes, you have a chance to successfully mine a block\n- In real life, the time for mining a block is around 10 minutes";
    }

    public void ItemHint(){
        hintPanel.SetActive(true);
        hintText.text = "- The most common mining equipment are computer, graphic card, and ASIC\n- Computer and graphic cards are standard equipment, they are cheaper but has lower hashrate and bulkier\n- ASIC is specially designed circuit for mining cryptocurrencies. They are more expensive but has higher hashrate";
    }

    public void PriceHint(){
        hintPanel.SetActive(true);
        hintText.text = "- Bitcoin has a virtual value, and its price changes overtime\n- In game, the price changes is random\n- But in real life, the price is changed according to the trends and world events";
    }

    public void PoolHint(){
        hintPanel.SetActive(true);
        hintText.text = "- A mining pool is a place to gather all computation power from different users to increase mining chance\n- The block reward is shared among all members insdie the same pool\n- The most common sharing is spliting by the proportion of your hashrate over the pool hashrate";
    }

    public void InfoHint1(){
        hintPanel.SetActive(true);
        hintText.text = "- Hashrate: The computational power your equipment own. The higher the number, the more chance to mining a block\n- Wattage: The power consumption of your equipment. It does not affect your hashrate\n- Monthly electricity fee: The user needs to pay for the amount of electricity consumed for each month";
    }

    public void InfoHint2(){
        hintPanel.SetActive(true);
        hintText.text = "- Block reward: The reward in bitcoin when successfully mined a block. The block reward is halved for roughly every 4 years (210000 block mined)\n- Shared reward: The shared reward when joining a mined pool\n- Chance: The chance for mining a bitcoin per 10 minutes";
    }
}
