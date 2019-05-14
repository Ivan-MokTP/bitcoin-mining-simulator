using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoolListDisplayer : MonoBehaviour{

    //Get other objects
    GameStatManager gameStatManager;

    //Prefab
    GameObject poolFrame;
    GameObject confirmPanel;

    //Output var
    Pool[] poolList;

    void Start(){

        //Get other objects
        gameStatManager = GameObject.Find("GameStatManager").GetComponent<GameStatManager>();
        poolFrame = Resources.Load<GameObject>("Prefab/PoolFrame");
        confirmPanel = Resources.Load<GameObject>("Prefab/ConfirmPanel");

        ShowPool();
    }

    private void ShowPool(){
        foreach(Pool pool in PoolList.GetList()){

            //Get pool data from GSM
            poolFrame.transform.Find("PoolName").GetComponent<Text>().text = pool.poolName;
            poolFrame.transform.Find("Member").GetComponent<Text>().text = pool.member.ToString();
            poolFrame.transform.Find("Hashrate").GetComponent<Text>().text = pool.hashrate.ToString();
            float chance = pool.hashrate/gameStatManager.GetGlobalHashPower();
            poolFrame.transform.Find("Chance").GetComponent<Text>().text = (chance*100).ToString("N2")+"%";

            //Show pools
            GameObject poolItem = Instantiate(poolFrame, this.transform);

            //Get buttons
            poolItem.GetComponent<Button>().onClick.AddListener(() => OnPoolClick(pool));
        }
    }

    private void OnPoolClick(Pool pool){
        GameObject newPanel = Instantiate(confirmPanel, GameObject.Find("Interface").transform);
        newPanel.transform.Find("AlertPanel/QuestionPanel").GetComponent<Text>().text = "Are you sure you want to join "+pool.poolName+"?";
        newPanel.transform.Find("AlertPanel/ButtonContainer/YesButton").GetComponent<Button>().onClick.AddListener(() => OnYesClick(pool.poolId, newPanel));
        newPanel.transform.Find("AlertPanel/ButtonContainer/NoButton").GetComponent<Button>().onClick.AddListener(() => OnNoClick(newPanel));
    }

     public void OnYesClick(int poolId, GameObject newPanel){
        gameStatManager.SetCurrentPool(poolId);
        Destroy(newPanel);
    }

    public void OnNoClick(GameObject newPanel){
        Destroy(newPanel);
    }
}
