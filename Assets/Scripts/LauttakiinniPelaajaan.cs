using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauttakiinniPelaajaan : MonoBehaviour {
    public GameObject player; //pelaaja
    public Transform platform; //alusta johonka pelaaja kiinnitetään 
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.transform.SetParent(platform); //pelaajan siirretään alustan lapseksi
        }
    }

    private void OnTriggerExit(Collider other) //pelaajan hypättyä alustasta irrotetaan pelaa alustasta
    {
        player.transform.parent = null; //pelaajalla ei ole isäntää
    }
}
