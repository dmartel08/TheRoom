using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HMDInfoManager : MonoBehaviour
{
    // Check which device is loaded
    void Start()
    {
        if (!XRSettings.isDeviceActive)
        {
            Debug.Log("No headset plugged in.");
        }
        else if (XRSettings.isDeviceActive && (XRSettings.loadedDeviceName == "Mock HMD" || XRSettings.loadedDeviceName == "MockHMDDisplay"))
        {
            Debug.Log("Using Mock HMD");
        }
        else
        {
            Debug.Log("Headset " + XRSettings.loadedDeviceName + " is loaded and active");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
