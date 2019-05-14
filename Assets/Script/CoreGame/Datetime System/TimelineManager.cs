using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimelineManager : MonoBehaviour
{

    //Get other objects
    GameStatManager gameStatManager;
    DateTime dateTime;

    DateTime[] eventTime;

    int eventCounter;

    void Start(){

        gameStatManager = GameObject.Find("GameStatManager").GetComponent<GameStatManager>();

        eventTime = new DateTime[]{
            new DateTime(2010,1,1),
            new DateTime(2010,1,3)
        };

        UpdateTimeline();
        
    }

    public void ReloadTimeline(){
    }

    public void UpdateTimeline(){
        dateTime = gameStatManager.GetDateTime();

    }
}
