using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehavior : MonoBehaviour
{
    [SerializeField]
    private Light strobeLight;
    [SerializeField]
    private bool lightIsStrobing = false;


    private void Start()
    {
        AudioEvents.OnButtonTriggerEvent += ColorLight;
    }

    public void ColorLight(bool buttonOn)
    {
        lightIsStrobing = buttonOn;

        Debug.Log("In light script bool is : " + buttonOn);

        if(lightIsStrobing)
        {
            strobeLight.color = Color.red;
            //strobeLight.color = Color.Lerp(Color.red, Color.cyan, 1.0f * Time.deltaTime);

        } 
        if(!lightIsStrobing)
        {
            strobeLight.color = Color.white;
        }
        //if (strobeLight.color != Color.red)
        //{ 
        //    strobeLight.color = Color.red; 
        //}
        //else
        //{
        //    strobeLight.color = Color.white;
        //}
    }

    private void Update()
    {
        
        if(lightIsStrobing)
        {
         //   strobeLight.color = new Vector4(.01f * Time.deltaTime, .5f, .5f, 1.0f);
        }
    }

    public void OnDisable()
    {
        AudioEvents.OnButtonTriggerEvent -= ColorLight;
    }
}
