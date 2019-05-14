using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    //Get PassNode
    PassNode passNode;

    //Get cameras
    Camera introCam;
    Camera mainCam;

    //Get video
    VideoPlayer introVideo;

    //Get BGM
    AudioSource bgm;

    void Start(){

        passNode = GameObject.Find("PassNode").GetComponent<PassNode>();

        //Get cameras
        introCam = GameObject.Find("Intro Camera").GetComponent<Camera>();
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();

        introVideo = GetComponent<VideoPlayer>();

        bgm = GameObject.Find("AudioObject/BGM").GetComponent<AudioSource>();

        if (passNode.IsNewGame){
            PlayVideo();
        } else {
            mainCam.enabled = true;
            introCam.enabled = false;
        }
        
    }

    private void PlayVideo(){
        mainCam.enabled = false;
        introCam.enabled = true;
        Time.timeScale = 0f;

        introVideo.Play();
    }

    public void SkipVideo(){
        introVideo.Stop();
        introCam.enabled = false;
        mainCam.enabled = true;
        bgm.Play();
    }
}
