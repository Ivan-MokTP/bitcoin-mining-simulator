using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class QuestionManager : MonoBehaviour
{
    //Get other objects
    GameStatManager gameStatManager;
    public GameObject questionContainer;
    Question[] questionList;
    public Button[] choiceList = new Button[3];
    GameObject confirmButton;
    Text checkText;
    DateTimeManager dateTimeManager;

    //Local var
    int randQ;
    int selectedAnswer;
    float randTime;
    float questionChance = 0.1f;

    void Start()
    {

        Question q1 = new Question(
            "Which of the following is the feature of Blockchain?", 
            new string[] {
                "It is a centralized network where every block is passed to the central point for hashing",
                "Every user contains a copy of the blockchain",
                "Each block is hashed in aorund 10 seconds"},
            1
        );

        Question q2 = new Question(
            "Which of the following is NOT a component of a block?", 
            new string[] {
                "Content",
                "Hash of the next block",
                "Hash of this block"},
            1
        );

        Question q3 = new Question(
            "Successfully mining a block will reward user with _____.", 
            new string[] {
                "Free coupons",
                "Money",
                "Bitcoin"},
            2
        );

        Question q4 = new Question(
            "By comparing different mining equipment:", 
            new string[] {
                "ASIC has the best hashrate among all mining equipment",
                "Computer has better hashing power than ASIC",
                "ASIC is not designed to mine cryptocurrencies"},
            0
        );

        Question q5 = new Question(
            "Which of the following is a purpose of a mining pool?", 
            new string[] {
                "To gather computer resources to increase chance of mining bitcoin",
                "To modify the power of mining equipment to increase hashing power",
                "To identify some faulty blocks in the network and reject them"},
            0
        );

        questionList = new Question[] {q1, q2, q3, q4, q5};

        //Get other objects
        gameStatManager = GameObject.Find("GameStatManager").GetComponent<GameStatManager>();
        dateTimeManager = GameObject.Find("Interface/DateContainer").GetComponent<DateTimeManager>();

        //Set choices onclick listerner
        choiceList[0].onClick.AddListener(() => ClickAnswer(0));
        choiceList[1].onClick.AddListener(() => ClickAnswer(1));
        choiceList[2].onClick.AddListener(() => ClickAnswer(2));

        //Set confirm button
        confirmButton = transform.Find("OKButton").gameObject;
        confirmButton.SetActive(false);

        //Set check text
        checkText = transform.Find("CheckText").GetComponent<Text>();

        //Close question panel
        questionContainer.SetActive(false);

        //ShowQuestion();
    }

    //Decide when to show the challenge. 10% chance per day
    public void ShowQuestion(){
        randTime = UnityEngine.Random.Range(0f, 1f);
        if(randTime <= questionChance && !questionContainer.activeSelf){

            //Show question
            questionContainer.SetActive(true);
            Time.timeScale = 0f;
            randQ = UnityEngine.Random.Range(0, questionList.Length-1);
            transform.Find("Question").GetComponent<Text>().text = questionList[randQ].question;
            transform.Find("AnswerHolder/Answer1/Text").GetComponent<Text>().text = questionList[randQ].answers[0];
            transform.Find("AnswerHolder/Answer2/Text").GetComponent<Text>().text = questionList[randQ].answers[1];
            transform.Find("AnswerHolder/Answer3/Text").GetComponent<Text>().text = questionList[randQ].answers[2];
        }
    }

    //When user click on one of the answer
    private void ClickAnswer(int index){
        for (int i = 0; i < choiceList.Length; i++){
            choiceList[i].transform.Find("Text").GetComponent<Text>().color = Color.black;
        }

        selectedAnswer = index;
        choiceList[index].transform.Find("Text").GetComponent<Text>().color = Color.yellow;
        confirmButton.SetActive(true);
        confirmButton.GetComponent<Button>().onClick.AddListener(CheckAnswer);
        checkText.text = "";

    }

    //Check if the clicked answer is correct
    private void CheckAnswer(){
        confirmButton.SetActive(false);
        if (questionList[randQ].correctAnswer == selectedAnswer){
            GenReward();
            
            //Add challenge count
            Int64[] badgeCount = gameStatManager.GetBadgeCount();
            badgeCount[3] += 1;
            gameStatManager.SetBadgeCount(badgeCount);

        } else {
            checkText.text = "Sorry, wrong answer. Better work harder next time";
            checkText.color = Color.red;
        }

        choiceList[questionList[randQ].correctAnswer].transform.Find("Text").GetComponent<Text>().color = Color.green;
    }

    //Choose reward when correct
    private void GenReward(){
        checkText.text = "Bingo! ";
        checkText.color = Color.green;
        switch(UnityEngine.Random.Range(0, 6)){
            case 0:
                checkText.text += "You've earned ₿1 bitcoin!";
                gameStatManager.AddBitcoin(1);
                break;
            case 1:
                checkText.text += "You've earned ₿2 bitcoin!";
                gameStatManager.AddBitcoin(2);
                break;
            case 2:
                checkText.text += "You've earned ₿3 bitcoin!";
                gameStatManager.AddBitcoin(3);
                break;
            case 3:
                checkText.text += "You've earned $2000 cash!";
                gameStatManager.AddCash(2000);
                break;
            case 4:
                checkText.text += "You've earned 5% of your current cash!";
                gameStatManager.AddCash(gameStatManager.GetCash()*0.05f);
                break;
            case 5:
                checkText.text += "You've earned 10% of your current cash!";
                gameStatManager.AddCash(gameStatManager.GetCash()*0.1f);
                break;
            default:
                break;
        }
    }

    //For close button
    public void ClosePanel(){
        questionContainer.SetActive(false);
        dateTimeManager.ResetTimeScale();
        ResetPanel();

    }

    //Reset question panel text for next time
    private void ResetPanel(){
        for (int i = 0; i < choiceList.Length; i++){
            choiceList[i].transform.Find("Text").GetComponent<Text>().color = Color.black;
        }
        checkText.text = "Please choose the correct answer";
        checkText.color = Color.white;
    }
}
