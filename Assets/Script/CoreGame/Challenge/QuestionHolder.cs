using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionHolder : MonoBehaviour
{

    //Get other objects
    public GameObject questionContainer;
    Question[] questionList;
    public Button[] choiceList = new Button[3];
    GameObject confirmButton;
    Text checkText;

    int i;
    int selectedAnswer;

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

        //Set choices onclick listerner
        choiceList[0].onClick.AddListener(() => ClickAnswer(0));
        choiceList[1].onClick.AddListener(() => ClickAnswer(1));
        choiceList[2].onClick.AddListener(() => ClickAnswer(2));

        //Set confirm button
        confirmButton = transform.Find("OKButton").gameObject;
        confirmButton.SetActive(false);

        //Set check text
        checkText = transform.Find("CheckText").GetComponent<Text>();

        ShowQuestion();
    }

    public void ShowQuestion(){
        i = Random.Range(0, questionList.Length-1);
        Debug.Log(i);
        transform.Find("Question").GetComponent<Text>().text = questionList[i].question;
        transform.Find("AnswerHolder/Answer1/Text").GetComponent<Text>().text = questionList[i].answers[0];
        transform.Find("AnswerHolder/Answer2/Text").GetComponent<Text>().text = questionList[i].answers[1];
        transform.Find("AnswerHolder/Answer3/Text").GetComponent<Text>().text = questionList[i].answers[2];
    }

    private void ClickAnswer(int index){
        for (int i = 0; i < choiceList.Length; i++){
            choiceList[i].transform.Find("Text").GetComponent<Text>().color = Color.black;
        }

        selectedAnswer = index;
        choiceList[index].transform.Find("Text").GetComponent<Text>().color = Color.yellow;
        confirmButton.SetActive(true);
        confirmButton.GetComponent<Button>().onClick.AddListener(CheckAnswer);

    }

    private void CheckAnswer(){
        confirmButton.SetActive(false);
        if (questionList[i].correctAnswer == selectedAnswer){
            checkText.text = "Bingo!";
            checkText.color = Color.green;
        } else {
            checkText.text = "Sorry, wrong answer. Better work harder next time";
            checkText.color = Color.red;
        }

        choiceList[questionList[i].correctAnswer].transform.Find("Text").GetComponent<Text>().color = Color.green;
    }

    public void ClosePanel(){
        Debug.Log("Close");
        questionContainer.SetActive(false);
    }
}