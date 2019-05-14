using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Manage bitcoin and blocks information
//1. #Block hashed
//2. Block rewards
public class BlockManager : MonoBehaviour
{
    //Singleton
    public BlockManager blockManager;

    //Get other objects
    private GameStatManager gameStatManager;

    //Local var
    private float blockReward;
    int dailyBlock = 144;

    //Output var
    private int totalBlockHashed;

    void Start(){

        //Singleton
        blockManager = this;
        
        //Get other objects
        gameStatManager = GameObject.Find("GameStatManager").GetComponent<GameStatManager>();

        //Initialize
        //UpdateBlock();
    }

    public void UpdateBlock(){

        totalBlockHashed = gameStatManager.GetTotalBlockHashed();

        //Update values
        totalBlockHashed += dailyBlock; 
        blockReward = 50 / (Mathf.Pow(2, (totalBlockHashed / 210000))); 

        //To GSM
        gameStatManager.SetTotalBlockHashed(totalBlockHashed);
        gameStatManager.SetBlockReward(blockReward);
    }
}
