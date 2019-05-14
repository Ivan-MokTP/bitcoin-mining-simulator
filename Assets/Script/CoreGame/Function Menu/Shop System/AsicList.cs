using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AsicList
{
    private static List<Asic> list = new List<Asic>(){
        new Asic(0, "ProCore-LT", 8000, 50, 250, Resources.Load<Sprite>("Image/Item/asic01")),
        new Asic(1, "PowerX-G2", 8200, 48, 220, Resources.Load<Sprite>("Image/Item/asic02")),
        new Asic(2, "ProCore-EP", 9200, 58, 300, Resources.Load<Sprite>("Image/Item/asic03")),
        new Asic(3, "PowerX-G3", 9000, 55, 320, Resources.Load<Sprite>("Image/Item/asic04")),
        new Asic(4, "ProCore-CX", 12000, 65, 330, Resources.Load<Sprite>("Image/Item/asic05")),
        new Asic(5, "PowerX-G4", 14000, 72, 320, Resources.Load<Sprite>("Image/Item/asic06"))
    };

    public static List<Asic> GetList(){
        return list;
    }

        public static Asic FindItem(int id){
        foreach(Asic item in list){
            if (id == item.GetID()){
                return item;
            }
        }
        return null;
    }
}
