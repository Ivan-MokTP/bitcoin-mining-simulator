using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Pass info for game start
public class PassNode : MonoBehaviour
{

    //Get other objects
    GameStatManager gameStatManager;
    GameInitializer gameInitializer;
    TutorialManager tutorialManager;
    DatabaseHandler databaseHandler;


    //Local var
    public bool IsNewGame;
    string profileName;
    string result;

    void Awake(){
        DontDestroyOnLoad(gameObject);
    }

    void OnEnable(){
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable(){
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        if(scene.name == "CoreGameScene"){

            //Get other objects
            gameStatManager = GameObject.Find("GameStatManager").GetComponent<GameStatManager>();
            gameInitializer = GameObject.Find("GameStatManager").GetComponent<GameInitializer>();
            tutorialManager = GameObject.Find("TutorialCanvas").GetComponent<TutorialManager>();

            if (IsNewGame){
                gameInitializer.Init(profileName);
                tutorialManager.AskTutorial();
            } else {
                gameInitializer.Init("");
                gameStatManager.LoadGame(result);
            }
        }
    }

    //Load game
    public void SetLoadGame(string result){
        this.result = result;
        IsNewGame = false;
    }

    //New game
    public void SetNewGame(string profileName){
        this.profileName = profileName; 
        IsNewGame = true;
    }


}
