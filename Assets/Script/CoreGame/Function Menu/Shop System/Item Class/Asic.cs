using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Asic class and attributes
public class Asic : ShopItem{

    private int id;
    private string model;
    private int price;
    private int speed;
    private int watt;
    private Sprite image;

    public Asic(int id, string model, int price, int speed, int watt, Sprite image){
        this.id = id;
        this.model = model;
        this.price = price;
        this.speed = speed;
        this.watt = watt;
        this.image = image;
    }

    public int GetID(){ return id; }
    public string GetModel(){ return model; }
    public int GetPrice(){ return price; }
    public int GetSpeed(){ return speed; }
    public int GetWatt(){ return watt; }
    public Sprite GetImage(){ return image; }

}
