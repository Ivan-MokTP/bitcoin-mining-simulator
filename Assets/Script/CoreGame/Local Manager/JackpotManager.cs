using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Simulate when goes jackpot
public class JackpotManager : MonoBehaviour
{
    //Get other objects
    GameStatManager gameStatManager;
    AudioSource coinSonud;

    //Local var
    UnityEngine.Random ranNum;
    Int64[] badgeCount;

    void Start(){

        //Get other objects
        gameStatManager = GameObject.Find("GameStatManager").GetComponent<GameStatManager>();
        coinSonud = GameObject.Find("AudioObject/CoinSound").GetComponent<AudioSource>();
    }

    public void CalculateJackpot(){
        float rand = UnityEngine.Random.Range(0f,1f);
        float chance = gameStatManager.GetChance();
        if (chance >= rand){

            //If hit, add bitcoin
            gameStatManager.AddBitcoin(gameStatManager.GetSharedReward());

            //Play coin sound
            coinSonud.Play();

            //Add hit count for badge
            badgeCount = gameStatManager.GetBadgeCount();
            badgeCount[0] += 1;
            gameStatManager.SetBadgeCount(badgeCount);
        }
    }
}