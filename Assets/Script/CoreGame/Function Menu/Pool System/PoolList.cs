using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PoolList{

    private static List<Pool> list = new List<Pool>(){
        new Pool(0, "Lasagna Pool", 200, 7f),
        new Pool(1, "Winnie the Pool", 400, 6.5f),
        new Pool(2, "Lava Pool", 700, 6.2f)
    };

    public static List<Pool> GetList(){
        return list;
    }

    public static Pool GetPool(int id){
        foreach (Pool pool in list){
            if (pool.poolId == id){
                return pool;
            }
        }
        return null;
    }
}
