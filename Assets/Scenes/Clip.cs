using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Clip : MonoBehaviour
{
    public AudioSource audioPlayer;
    public AudioClip eatClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayEatSound()
    {
        audioPlayer.PlayOneShot(eatClip);
    }
}
