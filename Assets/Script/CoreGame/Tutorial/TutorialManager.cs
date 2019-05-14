using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{

    //Get other objects
    private TutorialSet tutorialSet;
    private GameObject tutorialSetObject;
    PassNode passNode;

    private GameObject firstTimePanel;

    void Awake(){

        tutorialSet = transform.Find("TutorialSet").GetComponent<TutorialSet>();
        passNode = GameObject.Find("PassNode").GetComponent<PassNode>();
        

        tutorialSetObject = transform.Find("TutorialSet").gameObject;
        tutorialSetObject.SetActive(false);

        firstTimePanel = GameObject.Find("FirstTimePanel");
        if(passNode.IsNewGame){
            firstTimePanel.SetActive(true);
        } else {
            firstTimePanel.SetActive(false);
        }
    }

    public void AskTutorial(){
        firstTimePanel.SetActive(true);
    }

    public void PlayTutorial(bool yn){
        firstTimePanel.SetActive(false);
        if (yn){
            tutorialSetObject.SetActive(true);
        }
    }
}
