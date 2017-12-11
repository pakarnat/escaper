using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunIsGoingDown : MonoBehaviour {

    public Light sun;
    public float brightness = 1.2f;
    public float brightnessTicks = 0.005f;
    public float timeOfTicks = 1f;
    public float ticksStartingTime = 5f;
    public float darknessPower = 0.3f;


	// Use this for initialization
	void Start () {
        sun.intensity = brightness;
        darkness();
	}

    private void darkness()
    {
        if (sun.intensity > (darknessPower + brightnessTicks))
        {
            sun.intensity += -(brightnessTicks);
            InvokeRepeating("darkness", ticksStartingTime, timeOfTicks);
        }
    }
}
