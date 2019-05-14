using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class DatabaseHandler : MonoBehaviour
{

    void Awake(){
        DontDestroyOnLoad(gameObject);
    }
    
    // Save Game
    public IEnumerator SaveData(string profileName, string jsonString){

        WWWForm form = new WWWForm();
        form.AddField("profileName", profileName);
        form.AddField("jsonString", jsonString);

        using (UnityWebRequest wwww = UnityWebRequest.Post("http://localhost/BMS/SaveGame.php", form)) {
            yield return wwww.SendWebRequest();

            if (wwww.isNetworkError || wwww.isHttpError){
                Debug.Log(wwww.error);
            } else {
                //Log data
                Debug.Log(wwww.downloadHandler.text);
            }
        }
    }

    // Load Game
    public IEnumerator LoadData(System.Action<string> result){
        using (UnityWebRequest wwww = UnityWebRequest.Get("http://localhost/BMS/LoadGame.php")) {
            yield return wwww.SendWebRequest();

            if (wwww.isNetworkError || wwww.isHttpError){
                Debug.Log(wwww.error);
            } else {
                result(wwww.downloadHandler.text);
            }
        }
    }
}
