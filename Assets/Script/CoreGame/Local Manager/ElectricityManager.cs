using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handle daily electricity and electricity fee
//Deduct money from bill
public class ElectricityManager : MonoBehaviour
{

    //Get other objects
    private GameStatManager gameStatManager;

    //Local var
    int currentMonth;
    int newMonth;
    public float unitCost = 0.1f;

    //Output var
    private float dailyElectricity;
    private float monthlyElectricityFee;


    void Start(){

        //Get other objects
        gameStatManager = GameObject.Find("GameStatManager").GetComponent<GameStatManager>();

        //Initialize;
        monthlyElectricityFee = gameStatManager.GetMonthlyElectricityFee();
        currentMonth = gameStatManager.GetDateTime().Month;  

        //To GSM
        //UpdateDailyElectricity(gameStatManager.GetWatt());
    }

    void Update(){
        
        newMonth = gameStatManager.GetDateTime().Month;

        //Deduct money from month electricity bill and reset
        if(currentMonth != newMonth){
            currentMonth = newMonth;
            if(gameStatManager.IsEnoughCash(monthlyElectricityFee)){
                gameStatManager.DeductCash(monthlyElectricityFee);
                monthlyElectricityFee = 0f;

                //To GSM
                gameStatManager.SetMonthlyElectricityFee(0f);
            }
        }
    }

    public void UpdateMonthlyElectricityFee(){
        monthlyElectricityFee += dailyElectricity*unitCost;

        //To GSM
        gameStatManager.SetMonthlyElectricityFee(monthlyElectricityFee);
    }

    public void UpdateDailyElectricity(int watt){
        dailyElectricity = watt*24/1000f;

        //To GSM
        gameStatManager.SetDailyElectricity(dailyElectricity);
    }
}