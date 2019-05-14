using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnClick : MonoBehaviour
{

    //
    AudioSource pop;

    void Start(){

        pop = GetComponent<AudioSource>();
        
    }

    void Update(){
        if (Input.GetMouseButton(0)){
            pop.volume = 0.5f;
            pop.Play();
        }
    }
}
