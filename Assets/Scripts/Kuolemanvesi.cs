using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kuolemanvesi : MonoBehaviour {
    public GameObject pelaaja;
    Vector3 spawn =  new Vector3(3190, 48, 3070);
    [SerializeField]
    private Text _DeathText;
    
    // Use this for initialization

    void OnTriggerEnter(Collider other)
    {
        pelaaja.transform.position = spawn;
        _DeathText.enabled = true;
        StartCoroutine(Deathnode());
    }
    IEnumerator Deathnode()
    {
        yield return new WaitForSeconds(3);
        _DeathText.enabled = false;
        yield break;
        
    }
}
