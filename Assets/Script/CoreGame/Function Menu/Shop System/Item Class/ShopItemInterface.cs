using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ShopItem
{
    int GetID();
    string GetModel();
    int GetPrice();
    int GetSpeed();
    int GetWatt();
    Sprite GetImage();
}