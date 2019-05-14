using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//Manage datetime
public class DateTimeManager : MonoBehaviour
{
    //Singleton
    public DateTimeManager dateManager;

    //Get other objects
    private GameStatManager gameStatManager;

    //Local var
    private Text displayTime;
    private Text displayDate;
    private Image timeScaleImage;
    float counter;
    int dayCounter;

    //Get speed icon
    public Sprite slow;
    public Sprite medium;
    public Sprite fast;

    //Output var
    public DateTime dateTime;
    private DateTime endTime;

    void Start(){

        //Singleton
        dateManager = this;

        //Get other objects
        gameStatManager = GameObject.Find("GameStatManager").GetComponent<GameStatManager>();
        displayDate = transform.Find("Date").gameObject.GetComponent<Text>();
        displayTime = transform.Find("Time").gameObject.GetComponent<Text>();
        timeScaleImage = transform.Find("TimeScale").gameObject.GetComponent<Image>();

        //Initialize
        dateTime = gameStatManager.GetDateTime();
        endTime = new DateTime(2140, 01, 01);

        //Set default
        Time.timeScale = 1;
        timeScaleImage.sprite = slow;
        counter = 0f; 
        dayCounter = 0;
    }

    void Update()
    {
        counter += Time.deltaTime;

        if (counter >= 1f / Time.timeScale){
            counter -= 1f / Time.timeScale;

            //Add 10 muinutes
            dateTime = dateTime.AddMinutes(10);

            //Add dayCounter
            dayCounter++;
            if(dayCounter >= 144){
                dayCounter = 0;
                gameStatManager.AddTotalDay();
            }

            //Display datetime
            displayDate.text = dateTime.ToString("dd MMM, yyyy");
            displayTime.text = dateTime.ToString("h:mmtt");  

            //To GSM
            gameStatManager.SetDateTime(dateTime);

            //End-game
            if (dateTime >= endTime){
                Time.timeScale = 0f;
                Debug.Log("End Game");
            }
        }
    }

    //Button function
    public void ChangeTimeScale(){

        // 1f = 10mins/sec || 6f = 1hrs/sec || 36f = 6hrs/sec
        if (Time.timeScale == 1f){
            Time.timeScale = 6f;
            timeScaleImage.sprite = medium;
        }
        else if (Time.timeScale == 6f){
            Time.timeScale = 12f;
            timeScaleImage.sprite = fast;
        }
        else {
            Time.timeScale = 1f;
            timeScaleImage.sprite = slow;
        }
    }

    public void ResetTimeScale(){
        Time.timeScale = 1f;
        timeScaleImage.sprite = slow;
    }


}
