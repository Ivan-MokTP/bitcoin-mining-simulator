using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool{

    public int poolId;
    public string poolName;
    public int member;
    public float hashrate;
    public float ratio;
    public float chance;

    public Pool(int poolId, string poolName, int member, float ratio){
        this.poolId = poolId;
        this.poolName = poolName;
        this.member = member;
        this.ratio = ratio;

        hashrate = ratio*member;
    }

    
}
