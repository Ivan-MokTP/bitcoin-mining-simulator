using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Manage chance and expected earning
public class ExpectationManager : MonoBehaviour
{
    //Get other objects
    GameStatManager gameStatManager;
    ElectricityManager electricityManager;

    //Local var
    float speed;
    float globalHashPower;
    float sharedReward;
    float dailyElectricity;
    float bitcoinPrice;
    int currentPool;

    //Output var
    float chance;
    float expectedEarning;

    void Start(){

        //Get other objects
        gameStatManager = GameObject.Find("GameStatManager").GetComponent<GameStatManager>();
        electricityManager = GameObject.Find("LocalManagerContainer").GetComponent<ElectricityManager>();

        //Initialize
        //UpdateChance();
    }

    public void UpdateChance(){

        //Get GSM
        speed = gameStatManager.GetSpeed();
        globalHashPower = gameStatManager.GetGlobalHashPower();
        sharedReward = gameStatManager.GetSharedReward();
        dailyElectricity = gameStatManager.GetDailyElectricity();
        currentPool = gameStatManager.GetCurrentPool();
        bitcoinPrice = gameStatManager.GetBitcoinValue();

        if (currentPool == -1){
            chance = speed/globalHashPower;
        } else {
            chance = (PoolList.GetPool(currentPool).hashrate+speed)/globalHashPower;
        }
        
        expectedEarning = (chance*sharedReward*bitcoinPrice)*144-(dailyElectricity*electricityManager.unitCost);

        //To GSM
        gameStatManager.SetChance(chance);
        gameStatManager.SetExpectedEarning(expectedEarning);
    }
}