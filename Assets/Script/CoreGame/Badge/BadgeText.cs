using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BadgeText : MonoBehaviour
{

    //Get other objects
    public Text reminderText;

    //Button b1, b2, b3, b4, b5, b6;
    Button[] buttons = new Button[12];

    void Start(){

        for (int i = 1; i < buttons.Length+1; i++){
            buttons[i-1] = transform.Find(i.ToString()).GetComponent<Button>();
        }

        buttons[0].onClick.AddListener(() => ShowText(1));
        buttons[1].onClick.AddListener(() => ShowText(2));
        buttons[2].onClick.AddListener(() => ShowText(3));
        buttons[3].onClick.AddListener(() => ShowText(4));
        buttons[4].onClick.AddListener(() => ShowText(5));
        buttons[5].onClick.AddListener(() => ShowText(6));
        buttons[6].onClick.AddListener(() => ShowText(7));
        buttons[7].onClick.AddListener(() => ShowText(8));
        buttons[8].onClick.AddListener(() => ShowText(9));
        buttons[9].onClick.AddListener(() => ShowText(10));
        buttons[10].onClick.AddListener(() => ShowText(11));
        buttons[11].onClick.AddListener(() => ShowText(12));

    }

    private void ShowText(int i){
        switch(i){
            case 1:
                reminderText.text = "Get bitcoin reward for 1 time";
                break;
            case 2:
                reminderText.text = "Get bitcoin reward for 100 times";
                break;
            case 3:
                reminderText.text = "Get bitcoin reward for 5000 times";
                break;
            case 4:
                reminderText.text = "Complete trading 1 time";
                break;
            case 5:
                reminderText.text = "Complete trading 100 times";
                break;
            case 6:
                reminderText.text = "Complete trading 2000 times";
                break;
            case 7:
                reminderText.text = "Own $10,000 cash";
                break;
            case 8:
                reminderText.text = "Own $1,000,000 cash";
                break;
            case 9:
                reminderText.text = "Own $1,000,000,000 cash";
                break;
            case 10:
                reminderText.text = "Complete 10 challenges";
                break;
            case 11:
                reminderText.text = "Complete 50 challenges";
                break;
            case 12:
                reminderText.text = "Complete 100 challenges";
                break;
            default:
                reminderText.text = "---";
                break;
        }
    }
}
