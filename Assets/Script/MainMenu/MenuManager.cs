using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class MenuManager : MonoBehaviour
{

    //Pass and load data
    PassNode passNode;
    DatabaseHandler databaseHandler;

    //Get other objects
    GameObject loadGameWarningPanel;
    InputField profileName;
    GameObject warningPanel;

    void Awake(){
        //Pass and load data
        passNode = GameObject.Find("PassNode").GetComponent<PassNode>();
        databaseHandler = GameObject.Find("Database").GetComponent<DatabaseHandler>();

        //Get other data
        loadGameWarningPanel = GameObject.Find("Interface/LoadGameWarningPanel");
        loadGameWarningPanel.SetActive(false);
        warningPanel = GameObject.Find("Interface/WarningContainer");
        warningPanel.SetActive(false);
        profileName = transform.Find("ProfileNameInputField").GetComponent<InputField>();
    }

    // Save game ====================================================================================================
    public void RequestNewGame(){

        //Check input field for profile name
        if (profileName.text == ""){
            profileName.transform.Find("Placeholder").GetComponent<Text>().text = "Please enter your name first!";
        } else {
            StartCoroutine(NewGame());
        }
    }

    IEnumerator NewGame(){
        string result = "";
        //Check if saved game exists
        yield return StartCoroutine(databaseHandler.LoadData(s=>result = s));
        if (result == "EmptySave"){
            //Good, no save
            passNode.SetNewGame(profileName.text);
        } else {
            //Bad, has save, overwrite?
            warningPanel.SetActive(true);
        }
    }

    //----- Save overwrite warning -----
    public void OverwriteGame(bool yn){
        warningPanel.SetActive(false);
        if (yn){   
            passNode.SetNewGame(profileName.text);
            SceneManager.LoadScene("CoreGameScene");
        }
    }

    // Load game =========================================================================================================
    public void RequestLoadGame(){
        StartCoroutine(LoadGame());
    }

    IEnumerator LoadGame(){
        string result = "";
        yield return StartCoroutine(databaseHandler.LoadData(s=>result = s));
        if (result == "EmptySave"){
            //Saved game not found;
            loadGameWarningPanel.SetActive(true);
        } else {
            //Saved game found;
            passNode.SetLoadGame(result);
            SceneManager.LoadScene("CoreGameScene");
        }
    }

    public void QuitApp(){
        Application.Quit();    
    }

    //----- Close panel -----

    public void LoadCancel(){
        loadGameWarningPanel.SetActive(false);
    }

}
