using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Display empty or current pool
//Quit current pool
public class CurrentPoolDisplayer : MonoBehaviour
{

    //Get other objects
    GameStatManager gameStatManager;
    GameObject yesPanel;
    GameObject noPanel;

    //Local var
    int currentPool;
    void Start(){
        
        //Get other objects
        gameStatManager = GameObject.Find("GameStatManager").GetComponent<GameStatManager>();
        yesPanel = transform.Find("YesPool").gameObject;
        yesPanel.SetActive(false);
        noPanel = transform.Find("NoPool").gameObject;
        noPanel.SetActive(false);
    }

    void Update(){
        if (this.gameObject.activeSelf){
            currentPool = gameStatManager.GetCurrentPool();
            if (currentPool == -1){
                noPanel.SetActive(true);
                yesPanel.SetActive(false);
            } else {
                yesPanel.SetActive(true);
                noPanel.SetActive(false);
                ShowPoolData();
            }
        }
    }

    private void ShowPoolData(){
        Pool pool = PoolList.GetPool(currentPool);
        yesPanel.transform.Find("MiningPoolName").GetComponent<Text>().text = pool.poolName;
        float totalHashrate = pool.hashrate+gameStatManager.GetSpeed();
        yesPanel.transform.Find("MainPanel/ChanceValue").GetComponent<Text>().text = ((totalHashrate/gameStatManager.GetGlobalHashPower())*100).ToString("N2")+"%";
        yesPanel.transform.Find("MainPanel/HashrateValue").GetComponent<Text>().text = (pool.hashrate+gameStatManager.GetSpeed()).ToString();
        yesPanel.transform.Find("MainPanel/MemberValue").GetComponent<Text>().text = pool.member.ToString();
    }

    public void QuitPool(){
        gameStatManager.SetCurrentPool(-1);
    }
}
