using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//1. Update equipment and block information
public class MiningInfoManager : MonoBehaviour
{
    //Get other objects
    private GameStatManager gameStatManager;
    private GameObject miningInfoPanel;

    //Local var
    private float speed;
    private float watt;
    private float dailyElectricity;
    private float monthlyEletricityFee;
    private float blockReward;
    private float sharedReward;
    private float chance;
    private float expectedEarning;

    void Start(){

        //Get other objects
        gameStatManager = GameObject.Find("GameStatManager").GetComponent<GameStatManager>();
        miningInfoPanel = GameObject.Find("MiningInfoPanel");

        //Initialize
        miningInfoPanel.SetActive(false);
        UpdateSpeed();
        UpdateWatt();
        UpdateDailyElectricity();
        UpdateMonthlyElectricityFee();
        UpdateBlockReward();
        UpdateSharedReward();
        UpdateChance();
        UpdateExpectedEarning();
    }

    void Update(){

        //Update mining info
        if (miningInfoPanel.activeSelf){
            transform.Find("MiningInfoPanel/EquipmentInfoContainer/InnerFrame/SpeedValue").GetComponent<Text>().text = speed.ToString("N1");
            transform.Find("MiningInfoPanel/EquipmentInfoContainer/InnerFrame/WattageValue").GetComponent<Text>().text = watt.ToString("N0");
            transform.Find("MiningInfoPanel/EquipmentInfoContainer/InnerFrame/ElectricityValue").GetComponent<Text>().text = dailyElectricity.ToString("N2");
            transform.Find("MiningInfoPanel/EquipmentInfoContainer/InnerFrame/ElectricityFeeValue").GetComponent<Text>().text = monthlyEletricityFee.ToString("N2");

            transform.Find("MiningInfoPanel/RewardInfoContainer/InnerFrame/BlockRewardValue").GetComponent<Text>().text = "₿ "+blockReward.ToString("N2");
            transform.Find("MiningInfoPanel/RewardInfoContainer/InnerFrame/SharedRewardValue").GetComponent<Text>().text = "₿ "+sharedReward.ToString("N2");
            string chanceValue = (chance*100).ToString("N2") + "%";
            transform.Find("MiningInfoPanel/RewardInfoContainer/InnerFrame/ChanceValue").GetComponent<Text>().text = chanceValue;
            transform.Find("MiningInfoPanel/RewardInfoContainer/InnerFrame/ExpectedEarningValue").GetComponent<Text>().text = "$ "+expectedEarning.ToString("N2");
        }
    }

    public void ShowMiningInfo(){
        if (miningInfoPanel.activeSelf) miningInfoPanel.SetActive(false);
        else miningInfoPanel.SetActive(true);   
    }

    //On values change
    public void UpdateSpeed(){
        speed = gameStatManager.GetSpeed();
    }

    public void UpdateWatt(){
        watt = gameStatManager.GetWatt();
    }
    
    public void UpdateDailyElectricity(){
        dailyElectricity = gameStatManager.GetDailyElectricity();
    }

    public void UpdateMonthlyElectricityFee(){
        monthlyEletricityFee = gameStatManager.GetMonthlyElectricityFee();
    }

    public void UpdateBlockReward(){
        blockReward = gameStatManager.GetBlockReward();
    }
    
    public void UpdateSharedReward(){
        sharedReward = gameStatManager.GetSharedReward();
    }

    public void UpdateChance(){
        chance = gameStatManager.GetChance();
    }

    public void UpdateExpectedEarning(){
        expectedEarning = gameStatManager.GetExpectedEarning();
    }
}