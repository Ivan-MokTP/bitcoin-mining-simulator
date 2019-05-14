using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NonceManager : MonoBehaviour
{

    public GameObject rule;
    public Text input;
    public Text output;
    public Text statusText;
    public List<GameObject> nonceList = new List<GameObject>();
    private List<float> nonceValue = new List<float>();



    void Start(){
        foreach (Transform child in transform.Find("NonceGrid")){
            nonceList.Add(child.gameObject);
        }

        for (int i = 0; i < nonceList.Count; i++){
            string nonce = nonceList[i].transform.Find("Text").GetComponent<Text>().text;
            int index = i;
            nonceList[i].GetComponent<Button>().onClick.AddListener(() => SetValue(index));

            //Randomize nonce values
            nonceValue.Add(Random.Range(0f, 1f));
        }

        nonceValue[Random.Range(0, nonceList.Count)] = Random.Range(0f, 0.0852f);
    }

    void SetValue(int i){

        //Disable button
        nonceList[i].GetComponent<Button>().interactable = false;

        input.text = nonceList[i].transform.Find("Text").GetComponent<Text>().text;
        output.text = nonceValue[i].ToString();
        if (nonceValue[i]> 0.0852){
            statusText.text = nonceValue[i]+" is larger than 0.0852...try again";
            statusText.color = Color.red;
        } else {
            statusText.text = nonceValue[i]+" is smaller than 0.0852! You got the right nonce!";
            statusText.color = Color.green;
        }
    }

    public void ClosePanel(){
        rule.SetActive(false);
    }
}
