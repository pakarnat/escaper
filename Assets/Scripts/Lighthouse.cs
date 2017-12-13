using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighthouse : MonoBehaviour {

    [SerializeField]
    private Light spotlight;
    [SerializeField]
    private Light lightHalo;
	// Use this for initialization
	
	
	// Update is called once per frame
	public void EnableLights()
    {
        spotlight.enabled = true;
        lightHalo.enabled = true;
    }
}
