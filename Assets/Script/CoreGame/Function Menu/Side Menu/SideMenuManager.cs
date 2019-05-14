using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMenuManager : MonoBehaviour
{
    private GameObject mainPanel;
    private GameObject shopMenu;
    private GameObject bitcoinMenu;
    private GameObject poolMenu;

    void Start(){
        shopMenu = GameObject.Find("Interface/FunctionContainer/FunctionPanel/ShopMenu").gameObject;
        shopMenu.SetActive(false);
        bitcoinMenu = GameObject.Find("Interface/FunctionContainer/FunctionPanel/BitcoinMenu").gameObject;
        bitcoinMenu.SetActive(false);
        poolMenu = GameObject.Find("Interface/FunctionContainer/FunctionPanel/PoolMenu").gameObject;
        poolMenu.SetActive(false);

        mainPanel = GameObject.Find("Interface/FunctionContainer/FunctionPanel").gameObject;
        mainPanel.SetActive(false);
    }

    public void ClosePanel(){
        shopMenu.SetActive(false);
        bitcoinMenu.SetActive(false);
        poolMenu.SetActive(false);
        mainPanel.SetActive(false);
    }

    public void ShopFunction(){
        ManagePanel(shopMenu);
    }

    public void BitcoinFunction(){
        ManagePanel(bitcoinMenu);
    }

    public void PoolFunction(){
        ManagePanel(poolMenu);
    }

    private void ManagePanel(GameObject panel){
        
        if (mainPanel.activeSelf){

            //If active, check if same panel
            if (panel.activeSelf){

                //If smae panel
                panel.SetActive(false);
                mainPanel.SetActive(false);
            } else {

                //If different panel
                shopMenu.SetActive(false);
                bitcoinMenu.SetActive(false);
                poolMenu.SetActive(false);

                panel.SetActive(true);
            }

        } else {

            //If not active, activate
            mainPanel.SetActive(true);
            panel.SetActive(true);
        }
    }
}
