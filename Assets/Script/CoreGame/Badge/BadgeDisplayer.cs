using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BadgeDisplayer : MonoBehaviour
{
     //Get other objects
    GameStatManager gameStatManager;
    public GameObject badgePanel;

    Image[] imageList;
    bool[] badgeList;

    void Start(){

        //Get other objects
        gameStatManager = GameObject.Find("GameStatManager").GetComponent<GameStatManager>();

        imageList = new Image[12];

        for (int i = 0; i < imageList.Length; i++){
            imageList[i] = badgePanel.transform.Find("BadgeContainer/"+(i+1)+"/Image").GetComponent<Image>();
        }

        badgePanel.SetActive(false);
        UpdateBadgeList();
    }

    public void UpdateBadgeList(){
        badgeList = gameStatManager.GetBadgeList();
        for (int i = 0; i < badgeList.Length; i++){
            if (badgeList[i]){
                imageList[i].color = Color.white;
            }
        }
    }

    public void ShowPanel(){
        if (badgePanel.activeSelf) badgePanel.SetActive(false);
        else badgePanel.SetActive(true);
    }
}
