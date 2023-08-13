using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenResolution : MonoBehaviour{
    void Start()
        {
            Resolution[] resolutions = Screen.resolutions;

            // Print the resolutions
            foreach (var res in resolutions)
            {
                Debug.Log(res.width + "x" + res.height + " : " + res.refreshRateRatio);
            }
        }
}