using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Store and show list of items bought
//Activate Inventory container
public class InventoryManager : MonoBehaviour
{
    //Inspector

    //Get other objects
    GameStatManager gameStatManager;
    private GameObject inventoryPanel; 

    //Get prefab
    GameObject itemFrame;   

    //Local var
    private List<int> computerList;
    private List<int> graphicCardList;
    private List<int> asicList;

    private Transform computerGrid;
    private Transform graphicCardGrid;
    private Transform asicGrid;

    private Dictionary<ShopItem, int> computerCount;
    private Dictionary<ShopItem, int> graphicCardCount;
    private Dictionary<ShopItem, int> asicCount;

    void Start()
    {
        //Get other objects
        gameStatManager = GameObject.Find("GameStatManager").GetComponent<GameStatManager>();

        //Get prefab
        itemFrame = Resources.Load<GameObject>("Prefab/InventoryItem");

        computerGrid = transform.Find("InventoryPanel/ComputerFrame/Grid");
        graphicCardGrid = transform.Find("InventoryPanel/GraphicCardFrame/Grid");
        asicGrid = transform.Find("InventoryPanel/AsicFrame/Grid");

        inventoryPanel = GameObject.Find("InventoryPanel");
        inventoryPanel.SetActive(false);
    }

    private void ProcessItemList(){
        computerList = gameStatManager.GetComputerList();
        graphicCardList = gameStatManager.GetGraphicCardList();
        asicList  = gameStatManager.GetAsicList();

        //Initialize
        computerCount = new Dictionary<ShopItem, int>();
        graphicCardCount = new Dictionary<ShopItem, int>();
        asicCount = new Dictionary<ShopItem, int>();

        //Computer
        foreach (int item in computerList){
            Computer computer = ComputerList.FindItem(item);

            if (computerCount.ContainsKey(computer)){
                //Already contains model
                computerCount[computer]++;
            } else {
                //No current model
                computerCount.Add(computer, 1);
            }
        }

        //Graphic card
        foreach (int item in graphicCardList){
            GraphicCard graphicCard = GraphicCardList.FindItem(item);

            if (graphicCardCount.ContainsKey(graphicCard)){
                //Already contains model
                graphicCardCount[graphicCard]++;
            } else {
                //No current model
                graphicCardCount.Add(graphicCard, 1);
            }
        }

        //Asic
        foreach (int item in asicList){
            Asic asic = AsicList.FindItem(item);

            if (asicCount.ContainsKey(asic)){
                //Already contains model
                asicCount[asic]++;
            } else {
                //No current model
                asicCount.Add(asic, 1);
            }
        }
    }

    // Display list of bought items
    public void ShowInvnetory()
    {
        ProcessItemList();
        if (inventoryPanel.activeSelf){
            inventoryPanel.SetActive(false);
        } else {
            
            //Delete current list
            foreach(Transform child in computerGrid){
                Destroy(child.gameObject);
            }
            foreach(Transform child in graphicCardGrid){
                Destroy(child.gameObject);
            }
            foreach(Transform child in asicGrid){
                Destroy(child.gameObject);
            }

            //Add updated list
            foreach (KeyValuePair<ShopItem, int> item in computerCount){   
                GameObject itemObject = Instantiate(itemFrame, computerGrid);
                itemObject.transform.Find("Model").GetComponent<Text>().text = item.Key.ToString();
                itemObject.transform.Find("Image").GetComponent<Image>().sprite = item.Key.GetImage();
                itemObject.transform.Find("Count").GetComponent<Text>().text = "x"+item.Value.ToString();
            }
            foreach (KeyValuePair<ShopItem, int> item in graphicCardCount){   
                GameObject itemObject = Instantiate(itemFrame, graphicCardGrid);
                itemObject.transform.Find("Model").GetComponent<Text>().text = item.Key.ToString();
                itemObject.transform.Find("Image").GetComponent<Image>().sprite = item.Key.GetImage();
                itemObject.transform.Find("Count").GetComponent<Text>().text = "x"+item.Value.ToString();
            }
            foreach (KeyValuePair<ShopItem, int> item in asicCount){   
                GameObject itemObject = Instantiate(itemFrame, asicGrid);
                itemObject.transform.Find("Model").GetComponent<Text>().text = item.Key.ToString();
                itemObject.transform.Find("Image").GetComponent<Image>().sprite = item.Key.GetImage();
                itemObject.transform.Find("Count").GetComponent<Text>().text = "x"+item.Value.ToString();
            }

            inventoryPanel.SetActive(true);
        }
    }
}
