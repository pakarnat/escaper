using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunIsGoingDown : MonoBehaviour {

    public Light sun; //valon lähde
    public float brightness = 1.2f; //Valon voimakkuus pelin alkaessa
    public float brightnessTicks = 0.005f; // paljonko kerralla vähennetään valoa
    public float timeOfTicks = 1f; // kauanko on vähennyksien välissä (1f = sekunti)
    public float ticksStartingTime = 5f; // milloinka aloitetaan valon vähennys
    public float darknessPower = 0.3f; // mitenkä pieneksi valo vähennetään


	// Use this for initialization
	void Start () {
        sun.intensity = brightness; // muutetaan valon alku arvo brightness arvoon
        InvokeRepeating("darkness", ticksStartingTime, timeOfTicks); // kutsutaan functiota
    }

    private void darkness()
    {
        if (sun.intensity > (darknessPower + brightnessTicks)) // jos valon arvo on enemmän kuin darknessPower ja brightnessTicks yhteensä 
        {
            sun.intensity += -(brightnessTicks); // vähennetään valon kirkkautta brighnessTicksin verran
        }
        else //jos valon arvo on siinä missä halutaan tai vähemmän niin lopetetaan looppi
        {
            CancelInvoke("darkness"); //peruutetaan looppi
        }
    }
}
