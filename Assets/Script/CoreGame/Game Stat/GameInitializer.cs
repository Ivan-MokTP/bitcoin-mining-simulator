using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameInitializer : MonoBehaviour
{
    //Singleton
    public GameInitializer gameInitializer;
    
    //Get other objects
    private GameStatManager gameStatManager;

    public void Awake(){

        //Singleton
        gameInitializer = this;

        //Get other objects
        gameStatManager = GetComponent<GameStatManager>();
        
    }

    public void Init(string profileName){

        gameStatManager.InitProfileName(profileName);
        gameStatManager.InitCash(1000f);
        gameStatManager.InitBitcoin(0f);

        gameStatManager.InitSpeed(0);
        gameStatManager.InitWatt(0);
        gameStatManager.InitDailyElectricity(0f);
        gameStatManager.InitMonthlyElectricityFee(0f);

        gameStatManager.InitDate(new DateTime(2010, 1, 1));
        Time.timeScale = 1f; //Default time scale
        gameStatManager.InitTotalDay(1);

        gameStatManager.InitTotalBlockHashed(105000);
        gameStatManager.InitBlockReward(50f);
        gameStatManager.InitSharedReward(50f);

        //NOTE Global hash power
        gameStatManager.InitGlobalHashPower(1000000);

        gameStatManager.InitChance(0f);
        gameStatManager.InitExpectedEarning(0f);

        gameStatManager.InitBitcoinValue(1000f);
        gameStatManager.InitBitcoinValueHistory(new Queue<float>());

        gameStatManager.InitCurrentPool(-1);

        gameStatManager.InitBadgeList(new bool[12]);
        gameStatManager.InitBadgeCount(new Int64[4]);

        gameStatManager.InitComputerList(new List<int>());
        gameStatManager.InitGraphicCardList(new List<int>());
        gameStatManager.InitAsicList(new List<int>());

    }

}
