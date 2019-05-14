using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ComputerList{

    private static List<Computer> list = new List<Computer>(){
        new Computer(0, "Nexus-500", 600, 8, 200, Resources.Load<Sprite>("Image/Item/pc01")),
        new Computer(1, "Razor-2070", 650, 12, 250, Resources.Load<Sprite>("Image/Item/pc02")),
        new Computer(2, "Nexus-600", 800, 12, 220, Resources.Load<Sprite>("Image/Item/pc03")),
        new Computer(3, "Razor-3070", 1000, 15, 270, Resources.Load<Sprite>("Image/Item/pc04")),
        new Computer(4, "Nexus-700", 1200, 17, 260, Resources.Load<Sprite>("Image/Item/pc05")),
        new Computer(5, "Razor-4070", 1250, 19, 290, Resources.Load<Sprite>("Image/Item/pc06"))
    };

    public static List<Computer> GetList(){
        return list;
    }

    public static Computer FindItem(int id){
        foreach(Computer item in list){
            if (id == item.GetID()){
                return item;
            }
        }
        return null;
    }
}