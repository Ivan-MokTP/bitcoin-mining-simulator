using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Manage bitcoin network info
//1. Global hash power
//2. Possibly difficulty
public class NetworkManager : MonoBehaviour
{
    //Singleton
    public NetworkManager networkManager;

    //Get other objects
    private GameStatManager gameStatManager;

    //Output var
    private float globalHashPower;

    void Start(){

        //Singleton
        networkManager = this;

        //Get other objects
        gameStatManager = GameObject.Find("GameStatManager").GetComponent<GameStatManager>();

        //Initialize
        globalHashPower = gameStatManager.GetGlobalHashPower();
    }

    public void UpdateNetwork(){

        //Update global hash power
        float growthRate = Random.Range(1.0005f, 1.0015f);
        globalHashPower = Mathf.Round(globalHashPower*(growthRate));

        //To GSM
        gameStatManager.SetGlobalHashPower(globalHashPower);
    }
}
