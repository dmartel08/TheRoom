using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Events;

public class AudioBehavior : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSpeaker;

    private void Awake()
    {
        AudioEvents.OnButtonTriggerEvent += ToggleAudio;
    }
    public void ToggleAudio(bool buttonOn)
    {
        //if (!audioSpeaker.isPlaying)
        //{
        //  //  Debug.Log("Play the audio");
        //    audioSpeaker.Play();
        //}
        //else
        //{
        //   // Debug.Log("Stop the audio");
        //    audioSpeaker.Stop();
        //}
        if (buttonOn)
        {
            //  Debug.Log("Play the audio");
            audioSpeaker.Play();
        }
        if(!buttonOn)
        {
            // Debug.Log("Stop the audio");
            audioSpeaker.Stop();
        }
    }

    public void OnDisable()
    {
        AudioEvents.OnButtonTriggerEvent -= ToggleAudio;
    }

}
