using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    [SerializeField]
    private Animator buttonAnimator;

    private void OnTriggerEnter(Collider other)
    {
       // Debug.Log(other.name + " entered the collider");
        Debug.Log("In collider script bool is : " + AudioEvents.buttonIsOn);
        buttonAnimator.SetTrigger("Press");
        AudioEvents.current.ButtonTriggerEvent(AudioEvents.buttonIsOn);
        Debug.Log("In collider script bool is : " + AudioEvents.buttonIsOn);

    }

    private void OnTriggerExit(Collider other)
    {
       // Debug.Log(other.name + " exited the button collider");
        buttonAnimator.SetTrigger("DePress");
        
    }
}
