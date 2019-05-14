using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Get the list of items and show in the shop
//Spawn item frame for each item
public class ItemContainerManager : MonoBehaviour
{
    //Get other objects
    GameStatManager gameStatManager;
    Text statusText;

    //Local var
    private GameObject computerGrid;
    private GameObject graphicCardGrid;
    private GameObject asicGrid;

    //Get self component
    public ScrollRect scrollRect;

    //Get prefab
    GameObject itemFrame;

    //Get script
    public IDScript idScript;


    void Start(){

        //Get other objects
        gameStatManager = GameObject.Find("GameStatManager").GetComponent<GameStatManager>();
        statusText = transform.parent.Find("StatusText").GetComponent<Text>();

        computerGrid = transform.Find("ComputerGrid").gameObject;
        graphicCardGrid = transform.Find("GraphicCardGrid").gameObject;
        asicGrid = transform.Find("AsicGrid").gameObject;

        //Get prefab
        itemFrame = Resources.Load<GameObject>("Prefab/ItemFrame");

        //Fill item values
        AddItem();

        //Show computer grid by default
        graphicCardGrid.SetActive(false);
        asicGrid.SetActive(false);
    }


    private void AddItem(){

        //Computer
        int id = 0;
        foreach (Computer item in ComputerList.GetList()){

            //Set attributes
            GameObject newItem = Instantiate(itemFrame, computerGrid.transform);
            newItem.GetComponent<IDScript>().id = id++;
            newItem.tag = "Computer";

            //Set displays
            newItem.transform.Find("Model").GetComponent<Text>().text = item.GetModel();
            newItem.transform.Find("Image").GetComponent<Image>().sprite = item.GetImage();
            newItem.transform.Find("Value").GetComponent<Text>().text = item.GetSpeed().ToString()+"\n"+item.GetWatt().ToString();
            newItem.transform.Find("Price").GetComponent<Text>().text = "$"+item.GetPrice();

            //Set button events
            Button itemButton = newItem.GetComponent<Button>();
            itemButton.onClick.AddListener(() => BuyItem(newItem));
        }

        //Graphic card
        id = 0;
        foreach(GraphicCard item in GraphicCardList.GetList()){
            GameObject newItem = Instantiate(itemFrame, graphicCardGrid.transform);
            newItem.GetComponent<IDScript>().id = id++;
            newItem.tag = "GraphicCard";

            newItem.transform.Find("Model").GetComponent<Text>().text = item.GetModel();
            newItem.transform.Find("Image").GetComponent<Image>().sprite = item.GetImage();
            newItem.transform.Find("Value").GetComponent<Text>().text = item.GetSpeed().ToString()+"\n"+item.GetWatt().ToString();
            newItem.transform.Find("Price").GetComponent<Text>().text = "$"+item.GetPrice();

            Button itemButton = newItem.GetComponent<Button>();
            itemButton.onClick.AddListener(() => BuyItem(newItem));
        }

        //Asic
        id = 0;
        foreach(Asic item in AsicList.GetList()){
            GameObject newItem = Instantiate(itemFrame, asicGrid.transform);
            newItem.GetComponent<IDScript>().id = id++;
            newItem.tag = "Asic";

            newItem.transform.Find("Model").GetComponent<Text>().text = item.GetModel();
            newItem.transform.Find("Image").GetComponent<Image>().sprite = item.GetImage();
            newItem.transform.Find("Value").GetComponent<Text>().text = item.GetSpeed().ToString()+"\n"+item.GetWatt().ToString();
            newItem.transform.Find("Price").GetComponent<Text>().text = "$"+item.GetPrice();

            Button itemButton = newItem.GetComponent<Button>();
            itemButton.onClick.AddListener(() => BuyItem(newItem));
        }

    }

    //Show list of items in the grid
    public void ShowComputerGrid(){
        graphicCardGrid.SetActive(false);
        asicGrid.SetActive(false);

        computerGrid.SetActive(true);
        scrollRect.content = (RectTransform) computerGrid.transform;     
    }

    public void ShowGraphicCardGrid(){
        asicGrid.SetActive(false);     
        computerGrid.SetActive(false);

        graphicCardGrid.SetActive(true);
        scrollRect.content = (RectTransform) graphicCardGrid.transform;
    }

    public void ShowAsicGrid(){
        graphicCardGrid.SetActive(false);       
        computerGrid.SetActive(false);

        asicGrid.SetActive(true);
        scrollRect.content = (RectTransform) asicGrid.transform;
    }

    //Buy item
    private void BuyItem(GameObject item){

        int itemId = item.GetComponent<IDScript>().id;
        int itemType = -1;
        ShopItem shopItem = null;

        if (item.tag == "Computer"){
            shopItem = ComputerList.FindItem(itemId);
            itemType = 0;
        } else if (item.tag == "GraphicCard"){
            shopItem = GraphicCardList.FindItem(itemId);
            itemType = 1;
        } else if (item.tag == "Asic"){
            shopItem = AsicList.FindItem(itemId);
            itemType = 2;
        }

        if (shopItem != null){
            if (gameStatManager.IsEnoughCash(shopItem.GetPrice())){
                gameStatManager.DeductCash(shopItem.GetPrice());
                gameStatManager.AddSpeed(shopItem.GetSpeed());
                gameStatManager.AddWatt(shopItem.GetWatt());

                if (itemType == 0) gameStatManager.AddComputer(itemId);
                else if (itemType == 1) gameStatManager.AddGrahpicCard(itemId);
                else if (itemType == 2) gameStatManager.AddAsic(itemId);
                else Debug.Log("Error: [ItemContainerManager][BuyItem][Cannot get itemType]");

                statusText.color = Color.green;
                statusText.text = "Model ["+shopItem.GetModel()+"] purchase successful!"; 
            } else {
                statusText.color = Color.red;
                statusText.text = "Not enough cash to buy model ["+shopItem.GetModel()+"]";
            }
        }

        


    }
}


