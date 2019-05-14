using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using UnityEditor;

public class GameStatManager : MonoBehaviour
{
    //Singleton
    public GameStatManager gameStatManager;

    //In-game values
    private string profileName;

    /* Curerncies */
    private float cash;
    private float bitcoin;

    /* Equipments */
    private float speed;
    private int watt;
    private float dailyElectricity;
    private float monthlyElectricityFee;

    /* Date */
    private DateTime dateTime;
    private int totalDay;

    /* Blocks */
    private int totalBlockHashed;
    private float blockReward;

    /* Hash Power */
    private float globalHashPower;

    /* Earning */
    private float chance;
    private float sharedReward;
    private float expectedEarning;

    /* Bitcoin */
    private float bitcoinValue;
    private Queue<float> bitcoinValueHistory;

    /* List of Pools */
    private int currentPool;

    /* Badges */
    private bool[] badgeList;
    private Int64[] badgeCount;

    /* Equipments */
    private List<int> computerList;
    private List<int> graphicCardList;
    private List<int> asicList;

    //Get database
    DatabaseHandler databaseHandler;

    //Get other objects
    TopBarManager topBarManager;
    BlockManager blockManager;
    NetworkManager networkManager;
    MiningInfoManager miningInfoManager;
    ExpectationManager expectationManager;
    JackpotManager jackpotManager;
    ElectricityManager eletricityManager;
    BitcoinManager bitcoinManager;
    CurrentPoolManager currentPoolManager;
    BadgeManager badgeManager;
    public BadgeDisplayer badgeDisplayer;
    QuestionManager questionManager;

    //Local var
    int curretMonth;

    void Awake(){

        //Singleton
        gameStatManager = this;
    }

    void Start(){

        //Get database
        databaseHandler = GameObject.Find("Database").GetComponent<DatabaseHandler>();

        //Get other objects
        topBarManager = GameObject.Find("Interface/TopBar").GetComponent<TopBarManager>();
        blockManager = GameObject.Find("GlobalManagerContainer").GetComponent<BlockManager>();
        networkManager = GameObject.Find("GlobalManagerContainer").GetComponent<NetworkManager>();
        expectationManager = GameObject.Find("LocalManagerContainer").GetComponent<ExpectationManager>();
        jackpotManager = GameObject.Find("LocalManagerContainer").GetComponent<JackpotManager>();
        eletricityManager = GameObject.Find("LocalManagerContainer").GetComponent<ElectricityManager>();
        miningInfoManager = GameObject.Find("Interface/MiningInfoContainer").GetComponent<MiningInfoManager>();
        bitcoinManager = GameObject.Find("GlobalManagerContainer").GetComponent<BitcoinManager>();
        currentPoolManager = GameObject.Find("LocalManagerContainer").GetComponent<CurrentPoolManager>();
        badgeManager = GameObject.Find("LocalManagerContainer").GetComponent<BadgeManager>();
        questionManager = GameObject.Find("Interface/QuestionContainer/QuestionPanel").GetComponent<QuestionManager>();

        //Initialize
        curretMonth = dateTime.Month;
    }

    // ANCHOR Cash ----------
    public float GetCash(){return cash;}
    public void AddCash(float value){
        cash += value;
        OnCashUpdate();
    }
    public void DeductCash(float value){
        cash -= value;
        OnCashUpdate();
    }
    public bool IsEnoughCash(float value){return cash >= value;}
    private void OnCashUpdate(){
        //Update database
        //SaveToJson();

        //Update displayer
        topBarManager.UpdateCash(cash);

        //Update badge
        badgeCount[2] = (Int64)cash;
        badgeManager.UpdateBadge();
    }

    // ANCHOR Bitcoin ----------
    public float GetBitcoin(){return bitcoin;}
    public void AddBitcoin(float value){
        bitcoin += value;
        OnBitcoinUpdate();
    }
    public void DeductBitcoin(float value){
        bitcoin -= value;
        OnBitcoinUpdate();
    }
    public bool IsEnoughBitcoin(float value){
        return bitcoin >= value;
    }
    private void OnBitcoinUpdate(){
        //Update database
        //SaveToJson();

        //Update displayer
        topBarManager.UpdateBitcoin(bitcoin);
    }

    // ANCHOR Username ----------
    public string GetProfileName(){return profileName;}

    // ANCHOR Speed ----------
    public float GetSpeed(){return speed;}
    /* public void SetSpeed(int value){speed = value;}*/
    public void AddSpeed(int value){
        speed += value;
        OnSpeedChange();
    }
    public void DeductSpeed(int value){
        speed -= value;
        OnSpeedChange();
    }
    private void OnSpeedChange(){
        expectationManager.UpdateChance();
        miningInfoManager.UpdateSpeed();
        currentPoolManager.UpdateSharedReward();
    }

    // ANCHOR Watt ----------
    public int GetWatt(){return watt;}
    /*public void SetWatt(int value){watt = value;}*/
    public void AddWatt(int value){
        watt += value;
        OnWattUpdate();
    } 
    public void DeductWatt(int value){
        watt -= value;
        OnWattUpdate();
    }
    private void OnWattUpdate(){
        eletricityManager.UpdateDailyElectricity(watt);
        miningInfoManager.UpdateWatt();
    }

    // ANCHOR Daily Electricity ----------
    public float GetDailyElectricity(){return dailyElectricity;}
    public void SetDailyElectricity(float value){
        dailyElectricity = value;
        OnDailyElectricityUpdate();
    }
    private void OnDailyElectricityUpdate(){
        expectationManager.UpdateChance();
        eletricityManager.UpdateMonthlyElectricityFee();
        miningInfoManager.UpdateDailyElectricity();
    }

    // ANCHOR Monthly Electricity Fee ----------
    public float GetMonthlyElectricityFee(){return monthlyElectricityFee;}
    public void SetMonthlyElectricityFee(float value){
        monthlyElectricityFee = value;
        OnMonthlyElectricityFeeUpdate();
    }
    public void AddElectricityFee(float value){
        monthlyElectricityFee += value;
        OnMonthlyElectricityFeeUpdate();
    }
    private void OnMonthlyElectricityFeeUpdate(){
        miningInfoManager.UpdateMonthlyElectricityFee();
    }

    // ANCHOR DateTime ----------
    public DateTime GetDateTime(){return dateTime;}
    public void SetDateTime(DateTime date) {
        this.dateTime = date;
        OnDateTimeUpdate();
    }
    private void OnDateTimeUpdate(){

        jackpotManager.CalculateJackpot();

        //New Day


        ///New Month
        if (curretMonth != dateTime.Month){
            curretMonth = dateTime.Month;
            OnNewMonth();
        }
    }
    private void OnNewMonth(){

    }

    // ANCHOR Total Day ----------
    public int GetTotalDay(){return totalDay;}
    public void AddTotalDay(){
        totalDay++;
        OnDayUpdate();
    }
    public void OnDayUpdate(){
        blockManager.UpdateBlock();
        networkManager.UpdateNetwork();
        eletricityManager.UpdateMonthlyElectricityFee();
        bitcoinManager.UpdateBitcoinValue();
        questionManager.ShowQuestion();
    }

    // ANCHOR Total Block Hashed ----------
    public int GetTotalBlockHashed(){return totalBlockHashed;}
    public void SetTotalBlockHashed(int value){totalBlockHashed = value;}

    // ANCHOR Block Reward ----------
    public float GetBlockReward(){return blockReward;}
    public void SetBlockReward(float value){
        blockReward = value;
        OnBlockRewardUpdate();
    }
    private void OnBlockRewardUpdate(){
        miningInfoManager.UpdateBlockReward();
    }

    // ANCHOR Global Hash Power ----------
    public float GetGlobalHashPower(){return globalHashPower;}
    public void SetGlobalHashPower(float value){
        globalHashPower = value;
        OnGlobalHashPowerUpdate();
    }
    private void OnGlobalHashPowerUpdate(){
        expectationManager.UpdateChance();
    }

    // ANCHOR Chance ----------
    public float GetChance(){return chance;}
    public void SetChance(float value){
        chance = value;
        OnChanceUpdate();
    }
    private void OnChanceUpdate(){
        miningInfoManager.UpdateChance();
    }

    //ANCHOR Shared Reward ----------
    public float GetSharedReward(){return sharedReward;}
    public void SetSharedReward(float value){
        sharedReward = value;
        OnSharedRewardUpdate();
    }
    private void OnSharedRewardUpdate(){
        miningInfoManager.UpdateSharedReward();
        expectationManager.UpdateChance();
    }


    // ANCHOR Expected Earning ----------
    public float GetExpectedEarning(){return expectedEarning;}
    public void SetExpectedEarning(float value){
        expectedEarning = value;
        OnExpectedEarningUpdate();
    }
    private void OnExpectedEarningUpdate(){
        miningInfoManager.UpdateExpectedEarning();
    }

    //ANCHOR Bitcoin Value ----------
    public float GetBitcoinValue(){return bitcoinValue;}
    public void SetBitcoinValue(float value){
        bitcoinValue = value;
        OnBitcoinValueUpdate();
    }
    public void OnBitcoinValueUpdate(){

    }
 
    //ANCHOR Bitcoin Value History ----------
    public Queue<float> GetBitcoinValueHistory(){return bitcoinValueHistory;}
    public void SetBitcoinValueHistory(Queue<float> value){
        bitcoinValueHistory = value;
        OnBitcoinValueHistoryUpdate();
    }
    private void OnBitcoinValueHistoryUpdate(){

    }

    //ANCHOR Current Pool ----------
    public int GetCurrentPool(){return currentPool;}
    public void SetCurrentPool(int id){
        currentPool = id;
        OnCurrentPoolUpdate();
    }
    private void OnCurrentPoolUpdate(){
        //expectationManager.UpdateChance();
        currentPoolManager.UpdateSharedReward();
    }

    //ANCHOR Badge List ----------
    public bool[] GetBadgeList(){return badgeList;}
    public void SetBadgeList(bool[] value){
        badgeList = value;
        OnBadgeListUpdate();
    }
    private void OnBadgeListUpdate(){
        badgeDisplayer.UpdateBadgeList();
    }

    //ANCHOR Badge Count ----------
    public Int64[] GetBadgeCount(){return badgeCount;}
    public void SetBadgeCount(Int64[] value){
        badgeCount = value;
        OnBadgeCountUpdate();
    }
    private void OnBadgeCountUpdate(){
        badgeManager.UpdateBadge();
    }

    //ANCHOR Equipment ----------
    public void AddComputer(int id){
        computerList.Add(id);
    }
    public void RemoveComputer(int id){
        computerList.Remove(id);
    }
    public List<int> GetComputerList(){
        return computerList;
    }

    public void AddGrahpicCard(int id){
        graphicCardList.Add(id);
    }
    public void RemoveGraphicCard(int id){
        graphicCardList.Remove(id);
    }
    public List<int> GetGraphicCardList(){
        return graphicCardList;
    }

    public void AddAsic(int id){
        asicList.Add(id);
    }
    public void RemoveAsic(int id){
        asicList.Remove(id);
    }
    public List<int> GetAsicList(){
        return asicList;
    }

    //Init Only ======================================================================================================================
    public void InitProfileName(string value){profileName = value;}
    public void InitCash(float value){cash = value;}
    public void InitBitcoin(float value){bitcoin = value;}
    public void InitSpeed(float value){speed = value;}
    public void InitWatt(int value){watt = value;}
    public void InitDailyElectricity(float value){dailyElectricity = value;}
    public void InitMonthlyElectricityFee(float value){monthlyElectricityFee = value;}
    public void InitDate(DateTime value){dateTime = value;}
    public void InitTotalDay(int value){totalDay = value;}
    public void InitTotalBlockHashed(int value){totalBlockHashed = value;}
    public void InitBlockReward(float value){blockReward = value;}
    public void InitGlobalHashPower(float value){globalHashPower = value;}
    public void InitChance(float value){chance = value;}
    public void InitSharedReward(float value){sharedReward = value;}
    public void InitExpectedEarning(float value){expectedEarning = value;}
    public void InitBitcoinValue(float value){bitcoinValue = value;}
    public void InitBitcoinValueHistory(Queue<float> value){bitcoinValueHistory = value;}
    public void InitCurrentPool(int value){currentPool = value;}
    public void InitBadgeList(bool[] value){badgeList = value;}
    public void InitBadgeCount(Int64[] value){badgeCount = value;}
    public void InitComputerList(List<int> value){computerList = value;}
    public void InitGraphicCardList(List<int> value){graphicCardList = value;}
    public void InitAsicList(List<int> value){asicList = value;}

    //Load Game Only =================================================================================================================
    public void LoadGame(string jsonString){
        jsonString = jsonString.Replace("\\", "").Remove(0,1);
        jsonString = jsonString.Remove(jsonString.Length-1,1);
        DataClass dataClass = new DataClass();
        JsonUtility.FromJsonOverwrite(jsonString, dataClass);
        
        this.profileName = dataClass.profileName;
        this.cash = dataClass.cash;
        this.bitcoin = dataClass.bitcoin;
        this.speed = dataClass.speed;
        this.watt = dataClass.watt;
        this.dailyElectricity = dataClass.dailyElectricity;
        this.monthlyElectricityFee = dataClass.monthlyElectricityFee;
        DateTime tempDateTime = new DateTime(dataClass.dateTime);
        this.dateTime = tempDateTime;
        this.totalDay = dataClass.totalDay;
        this.globalHashPower = dataClass.globalHashPower;
        this.bitcoinValue = dataClass.bitcoinValue;
        this.bitcoinValueHistory = new Queue<float>(dataClass.bitcoinValueHistory);
        this.currentPool = dataClass.currentPool;
        this.badgeList = dataClass.badgeList;
        this.computerList = dataClass.computerList;
        this.graphicCardList = dataClass.graphicCardList;
        this.asicList = dataClass.asicList;

    }

    //Save Game Only ===================================================================================================================
    private IEnumerator SaveGame(string jsonString){
        yield return StartCoroutine(databaseHandler.SaveData(profileName, jsonString));
    }


    public string SaveToJson(){

        //Create data class
        DataClass dataClass = new DataClass(profileName, cash, bitcoin, speed, watt, dailyElectricity, monthlyElectricityFee, dateTime, totalDay, currentPool, bitcoinValue, bitcoinValueHistory, globalHashPower, computerList, graphicCardList, asicList, badgeList);

        //Convert to json
        string jsonString = JsonUtility.ToJson(dataClass, false);

        //Save to PlayerPref
        PlayerPrefs.SetString("GameData", jsonString);

        //Save to file
        string path = Application.dataPath + "/Save.json";
        File.WriteAllText(path, jsonString);

        return jsonString;
    }

    void OnApplicationQuit(){
        String jsonString = SaveToJson();
        StartCoroutine(SaveGame(jsonString));
    }
}