using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialSet : MonoBehaviour
{

    //Get other objects
    private Text instructionText;
    private GameObject instructionBox;
    private GameObject largeTextBox;
    public GameObject[] tutorial;
    GameObject tutorialCanvas;
    public GameObject nonceCanvas;

    //Get tutorial buttons
    Button shoppingCartButton;
    Button closeButton;
    Button infoButton;
    Button poolButton;
    public Button nonceClose;

    //Local var
    private int index;
    private int[] clickIndex;

    void Start(){

        //Get other objects
        nonceCanvas.SetActive(false);
        tutorialCanvas = GameObject.Find("TutorialCanvas");
        instructionBox = transform.Find("TextPanel").gameObject;
        instructionText = transform.Find("TextPanel/InstructionText").GetComponent<Text>();
        largeTextBox = transform.Find("BroadPanel").gameObject;
        largeTextBox.SetActive(false);


        index = 0;
        clickIndex = new int[] {0,1,2,3,4,5,6,7,8,9,11,12,13,14,17,18,19,20,21,22,23,25,26,27,29,30,31,32,33,34,36,37,38,39,40};

        //Get tutorial buttons
        shoppingCartButton = GameObject.Find("Interface/FunctionContainer/SideMenuPanel/Shop").GetComponent<Button>();
        closeButton = GameObject.Find("Interface/FunctionContainer/FunctionPanel/CloseButton").GetComponent<Button>();
        infoButton = GameObject.Find("Interface/MiningInfoContainer/MiningInfoIcon").GetComponent<Button>();
        poolButton = GameObject.Find("Interface/FunctionContainer/SideMenuPanel/MiningPool").GetComponent<Button>();
    }

    void Update(){
        
        for (int i = 0; i < tutorial.Length; i++){
            if (i == index){
                tutorial[i].SetActive(true);
            } else {
                tutorial[i].SetActive(false);
            }
        }

        if (Input.GetMouseButtonUp(0)){
            if (System.Array.IndexOf(clickIndex, index) != -1){
                index++;
                Debug.Log("Index: "+index);
            }
        }

        if (index == 0){
            largeTextBox.SetActive(true);
            instructionText.text = "Welcome to Bitcoin Mining Simulator!!! After watching the video, you should now be familiar with the basic concept of bitcoin. Let's first review the important features of blockchain.";
     
        } else if (index == 6){
            largeTextBox.transform.Find("Title").GetComponent<Text>().text = "Blockchain and Bitcoin";
            instructionText.text = "The video mentioned that the block can store anything, for example bitcoin transaction. So how does that related to bitcoin mining?";
        } else if (index == 7){
            largeTextBox.transform.Find("Title").GetComponent<Text>().text = "What is Bitcoin Mining";
        } else if (index == 9){
            largeTextBox.transform.Find("Title").GetComponent<Text>().text = "Bitcoin Mining Simulator";
            instructionText.text = "In this game, you are a bitcoin miner. Your task is to use different equipments to mine bitcoin and earn money";
        } else if (index == 10){
            largeTextBox.SetActive(false);
            instructionText.text = "To mine bitcoin, please buy your first computer. Click on the shopping cart";
            shoppingCartButton.onClick.AddListener(Proceed01);
        } else if (index == 11){
            shoppingCartButton.onClick.RemoveListener(Proceed01);
            instructionText.text = "You are currently in the shop menu. You can buy all mining equipments here";
        } else if (index == 12){
            instructionText.text = "There are 3 types of equipments: 1. computer, 2. graphic card and 3. ASIC. Differnt equipments have different characteristics.";
        } else if (index == 13){
            instructionText.text = "Each item has unique attributes";
        } else if (index == 14){
            instructionText.text = "Now let's buy a computer. You can scroll to view more items";
        } else if (index == 15){
            instructionText.text = "Congrats! You have just bought your first computer. Now close the panel";
            closeButton.onClick.AddListener(Proceed02);
        } else if (index == 16){
            closeButton.onClick.RemoveListener(Proceed02);
            instructionText.text = "Click here to show all the statistics about your equipments";
            infoButton.onClick.AddListener(Proceed03);
        } else if (index == 17){
            infoButton.onClick.RemoveListener(Proceed03);
        } else if (index == 23){
            instructionText.text = "Er...look at the chance, it is so low. It is very difficult to earn money....... Oh, looks like there are some mining pools that you can join!";
        } else if (index == 24){
            instructionText.text = "Now click this icon to see the mining pools";
            poolButton.onClick.AddListener(Proceed04);
        } else if (index == 25 || index == 26){
            poolButton.onClick.RemoveListener(Proceed04);
            instructionText.text = "Each mining pool contains different hashrate and reward sharing. Join either one of the mining pool now";
        } else if (index == 28){
            instructionText.text = "Now close the panel";
            closeButton.onClick.AddListener(Proceed05);
        } else if (index == 29){
            closeButton.onClick.RemoveListener(Proceed05);
            instructionText.text = "You can see that the chance has increased! So what is mining pool?";
        } else if (index == 30){
            instructionText.text = "Mining pool is a to gather the processing power (hashrate) to increase the chance of mining a block.";
        } else if (index == 31){
            instructionText.text = "Since there are other members in the pool, the reward will be split in protortion to your hastrate over the pool's total hashrate";
        } else if (index == 32){
            instructionText.text = "You can compare the block reward with shared reward. This is a trade-off between the chance and the reward. But it usually benefits in the beginning";
        } else if (index == 33){
            instructionText.text = "For the last part, you are going to understand how mining equipment 'mine' blocks by solving complex problems";
        } else if (index == 34){
            instructionText.text = "The following mini game can help you understand the mining logic. Let's go!";
        } else if (index == 35){
            nonceCanvas.SetActive(true);
            instructionBox.SetActive(false);
            nonceClose.onClick.AddListener(Proceed06);
        } else if (index == 36){
            nonceClose.onClick.RemoveListener(Proceed06);
        } else if (index == 37){
            instructionBox.SetActive(true);
            instructionText.text = "What you did just now is to try hashing different numbers to see if the number is less than the target value. If so, then the block is hashed. ";
        } else if (index == 38){
            instructionText.text = "However, in real life the equipement need to try thousands and thousands of number before getting the right one. The more powerful your equipment are, the faster your computer can hash.";
        } else if (index == 39){
            instructionText.text = "Congratulations! Now you already have basic idea on how to play the game. You can now freely play the game. Have a nice day!";
        } else if (index >= 40){
            tutorialCanvas.SetActive(false);
        }
    }

    private void Proceed01(){
        index = 11;
    }

    private void Proceed02(){
        index = 16;
    }

    private void Proceed03(){
        index = 17;
    }

    private void Proceed04(){
        index = 25;
    }

    private void Proceed05(){
        index = 29;
    }

    private void Proceed06(){
        Debug.Log("GG");
        index = 36;
    }

    public void SkipTutorial(){
        tutorialCanvas.SetActive(false);
    }

    public void closePanel(){
        nonceCanvas.SetActive(false);
    }
}
