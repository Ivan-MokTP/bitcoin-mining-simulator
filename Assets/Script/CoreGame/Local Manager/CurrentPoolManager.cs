using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPoolManager : MonoBehaviour
{

    //Get other objects
    GameStatManager gameStatManager;
    public GameObject miningInfoPanel;

    //Local var
    int currentPool;
    int poolSpeed;

    //Output var
    float sharedReward;

    void Start(){
        
        //Get other objects
        gameStatManager = GameObject.Find("GameStatManager").GetComponent<GameStatManager>();

        //UpdateSharedReward();
    }

    public void UpdateSharedReward(){

        if (miningInfoPanel.activeSelf){
            currentPool = gameStatManager.GetCurrentPool();
            if(currentPool != -1){
                sharedReward = gameStatManager.GetBlockReward()*(gameStatManager.GetSpeed()/PoolList.GetPool(currentPool).hashrate);
            } else {
                sharedReward = gameStatManager.GetBlockReward();
            }    
            gameStatManager.SetSharedReward(sharedReward);
        }
    }
}
