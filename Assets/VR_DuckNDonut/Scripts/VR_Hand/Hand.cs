using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Hand : MonoBehaviour
{
    // Not to be confused with the speed of the animation. This is the speed of the value against time. Set the animation speed in the actual animator (on the blend tree/or w/e animation).
    public float speed = 10.0f;

    Animator animator;
    SkinnedMeshRenderer mesh;

    private float gripTarget;
    private float triggerTarget;
    private float gripCurrent;
    private float triggerCurrent;
    private string animatorGripParam = "Grip";
    private string animatorTriggerParam = "Trigger";


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //added importance - without this being set, animations would lock to last known frame (if user needs to be moved outside of normal cntrl etc)
        animator.keepAnimatorControllerStateOnDisable = true;

        mesh = GetComponentInChildren<SkinnedMeshRenderer>();
    }

    // Remember, update happens every frame. So movetowards is needed to match the grip/trigger input.
    void Update()
    {
        AnimateHand();
    }

    internal void SetGrip(float v)
    {
        gripTarget = v;
    }

    internal void SetTrigger(float v)
    {
        triggerTarget = v;
    }

    // Movetowards is important - your finger pressing the grip/trigger in real life is the targetValue. 
    void AnimateHand()
    {
        if(gripCurrent != gripTarget)
        {
            gripCurrent = Mathf.MoveTowards(gripCurrent, gripTarget, Time.deltaTime * speed);
            animator.SetFloat(animatorGripParam, gripCurrent);
        }
        if(triggerCurrent != triggerTarget)
        {
            triggerCurrent = Mathf.MoveTowards(triggerCurrent, triggerTarget, Time.deltaTime * speed);
            animator.SetFloat(animatorTriggerParam, triggerCurrent);
        }
    }

    // Adding this just to hide the hand when grabbing something
    // NOTE: THIS IS REFERENCED IN THE XR INTERACTOR SCRIPT UNDER THE EVENTS. Make sure to add this reference (like how button events are used...)
    public void ToggleVisibility()
    {
        mesh.enabled = !mesh.enabled;
    }
}
