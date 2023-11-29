using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioEvents : MonoBehaviour
{
    public static AudioEvents current;
    //this should read more as (can button be fired? so initial state needs to be true)
    public static bool buttonIsOn = true;

    public GameObject dancerGroup;

    private void Awake()
    {
        current = this;
    }

    public static event Action<bool> OnButtonTriggerEvent;
    public void ButtonTriggerEvent(bool buttonState)
    {
        //if(onButtonTriggerEvent != null)
        //{
        //    onButtonTriggerEvent();
        //}

        // buttonState comes in, when it comes in swap the state (e.g it was off, so since it was pressed it's now on, then invoke the fact that it's been pressed to on)
        // the buttonState is triggered outside this script, but the value that is being used in the other(s) script(s) look for the static bool here: buttonIsOn
        
        OnButtonTriggerEvent?.Invoke(buttonState);

        dancerGroup.SetActive(buttonIsOn);

        buttonIsOn = !buttonIsOn;
    }
}
