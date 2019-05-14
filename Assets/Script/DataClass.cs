using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class DataClass
{
    public string profileName;
    public float cash;
    public float bitcoin;

    public float speed;
    public int watt;
    public float dailyElectricity;
    public float monthlyElectricityFee;

    public long dateTime;
    public int totalDay;

    public int currentPool;

    public float bitcoinValue;
    public float[] bitcoinValueHistory;

    public float globalHashPower;

    public List<int> computerList;
    public List<int> graphicCardList;
    public List<int> asicList;

    public bool[] badgeList;

    public DataClass(){}

    public DataClass(
        string profileName, float cash, float bitcoin, float speed, int watt, float dailyElectricity, float monthlyElectricityFee, DateTime dateTime, int totalDay, int currentPool, float bitcoinValue, Queue<float> bitcoinValueHistory, float globalHashPower, List<int> computerList, List<int> graphicCardList, List<int> asicList, bool[] badgeList){
        this.profileName = profileName;
        this.cash = cash;
        this.bitcoin = bitcoin;
        this.speed = speed;
        this.watt = watt;
        this.dailyElectricity = dailyElectricity;
        this.monthlyElectricityFee = monthlyElectricityFee;
        this.dateTime = dateTime.ToBinary();
        this.totalDay = totalDay;
        this.currentPool = currentPool;
        this.bitcoinValue = bitcoinValue;
        this.bitcoinValueHistory = bitcoinValueHistory.ToArray();
        this.globalHashPower = globalHashPower;
        this.computerList = computerList;
        this.graphicCardList = graphicCardList;
        this.asicList = asicList;
        this.badgeList = badgeList;
    }
}
