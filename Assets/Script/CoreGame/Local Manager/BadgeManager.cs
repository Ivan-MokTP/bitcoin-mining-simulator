using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BadgeManager : MonoBehaviour{

    //Get other objects
    GameStatManager gameStatManager;
    DateTimeManager dateTimeManager;

    public GameObject newPanel;
    public GameObject[] badges;
    Button okButton;
    Transform badgePos;
    GameObject badgeObject;

    //0: Mining time
    //1: Trading time
    //2: Cash own
    //3: Challenge time
    Int64[] badgeCount;
    bool[] badgeList;

    void Start(){
        gameStatManager = GameObject.Find("GameStatManager").GetComponent<GameStatManager>();
        dateTimeManager = GameObject.Find("Interface/DateContainer").GetComponent<DateTimeManager>();

        okButton = newPanel.transform.Find("Button").GetComponent<Button>();
        okButton.onClick.AddListener(ClosePanel);
        badgePos = newPanel.transform.Find("BadgePlacer");
        newPanel.SetActive(false);

    }

    private void ClosePanel(){
        Destroy(badgeObject);
        newPanel.SetActive(false);
        dateTimeManager.ResetTimeScale();
    }

    public void UpdateBadge(){
        
        badgeCount = gameStatManager.GetBadgeCount();
        badgeList = gameStatManager.GetBadgeList();

        //Mining time
        if (badgeCount[0] == 1 && !badgeList[0]){
            badgeList[0] = true;
            badgeObject = Instantiate(badges[0], badgePos);
            Time.timeScale = 0;
            newPanel.SetActive(true);
        } else if (badgeCount[0] == 100 && !badgeList[1]){
            badgeList[1] = true;
            badgeObject = Instantiate(badges[1], badgePos);
            Time.timeScale = 0;
            newPanel.SetActive(true);
        } else if (badgeCount[0] == 5000 && !badgeList[2]){
            badgeList[2] = true;
            badgeObject = Instantiate(badges[2], badgePos);
            Time.timeScale = 0;
            newPanel.SetActive(true);
        } else if(badgeCount[1] == 1 && !badgeList[3]){
            //Trading time
            badgeList[3] = true;
            badgeObject = Instantiate(badges[3], badgePos);
            Time.timeScale = 0;
            newPanel.SetActive(true);
        } else if(badgeCount[1] == 100 && !badgeList[4]){
            badgeList[4] = true;
            badgeObject = Instantiate(badges[4], badgePos);
            Time.timeScale = 0;
            newPanel.SetActive(true);
        } else if(badgeCount[1] == 2000 && !badgeList[5]){
            badgeList[5] = true;
            badgeObject = Instantiate(badges[5], badgePos);
            Time.timeScale = 0;
            newPanel.SetActive(true);
        } else if (badgeCount[2] >= 10000 && badgeCount[2] < 1000000 && !badgeList[6]){
            //Cash own
            badgeList[6] = true;
            badgeObject = Instantiate(badges[6], badgePos);
            Time.timeScale = 0;
            newPanel.SetActive(true);
        } else if (badgeCount[2] >= 1000000 && badgeCount[2] < 1000000000 && !badgeList[7]){
            badgeList[7] = true;
            badgeObject = Instantiate(badges[7], badgePos);
            Time.timeScale = 0;
            newPanel.SetActive(true);
        } else if (badgeCount[2] >= 1000000000 && !badgeList[8]){
            badgeList[8] = true;
            badgeObject = Instantiate(badges[8], badgePos);
            Time.timeScale = 0;
            newPanel.SetActive(true);
        } else if (badgeCount[3] == 10 && !badgeList[9]){
            //Challenge time
            badgeList[9] = true;
            badgeObject = Instantiate(badges[9], badgePos);
            Time.timeScale = 0;
            newPanel.SetActive(true);
        } else if (badgeCount[3] == 50 && !badgeList[10]){
            badgeList[10] = true;
            badgeObject = Instantiate(badges[10], badgePos);
            Time.timeScale = 0;
            newPanel.SetActive(true);
        } else if (badgeCount[3] == 100 && !badgeList[11]){
            badgeList[11] = true;
            badgeObject = Instantiate(badges[11], badgePos);
            Time.timeScale = 0;
            newPanel.SetActive(true);
        }

        gameStatManager.SetBadgeList(badgeList);
    }
}
