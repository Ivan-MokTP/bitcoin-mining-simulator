using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GraphicCardList
{
        private static List<GraphicCard> list = new List<GraphicCard>(){
        new GraphicCard(0, "Rx-260", 850, 20, 150, Resources.Load<Sprite>("Image/Item/gpu01")),
        new GraphicCard(1, "GTX-780", 850, 22, 200, Resources.Load<Sprite>("Image/Item/gpu02")),
        new GraphicCard(2, "Rx-270", 1000, 30, 170, Resources.Load<Sprite>("Image/Item/gpu03")),
        new GraphicCard(3, "GTX-880", 1050, 35, 220, Resources.Load<Sprite>("Image/Item/gpu04")),
        new GraphicCard(4, "Rx-280", 1200, 38, 180, Resources.Load<Sprite>("Image/Item/gpu05")),
        new GraphicCard(5, "GTX-980", 1200, 40, 240, Resources.Load<Sprite>("Image/Item/gpu06"))

    };

    public static List<GraphicCard> GetList(){
        return list;
    }

        public static GraphicCard FindItem(int id){
        foreach(GraphicCard item in list){
            if (id == item.GetID()){
                return item;
            }
        }
        return null;
    }
}
