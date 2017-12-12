using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Kuolemanvesi : MonoBehaviour {
    public GameObject pelaaja; //pelaaja
    Vector3 spawn =  new Vector3(3190, 48, 3070); //kohta johonka pelaaja syntyy kuolemisen jälkeen
    [SerializeField]
    private Text _DeathText; //kuolemis teksti
    [SerializeField]
    private Button _yes; //kyllä nappi
    [SerializeField]
    private Button _no; //ei nappi
    [SerializeField]
    private Text _yestext; //kyllä napin teksti
    [SerializeField]
    private Text _notext; //ei napin teksti
    // Use this for initialization

    void OnTriggerEnter(Collider other) //pelaajan tiputtua veteen
    {
        if (other.gameObject.tag == "Player")
        {
            var Pmovement = pelaaja.GetComponent<PlayerMovement>(); //etsitään pelaajan liikkumis scripta
            var Ccontrol = pelaaja.GetComponent<CharacterController>(); //etsitään pelaajan scripta (painovoima jne)
            Pmovement.enabled = false; //otetaan liikkuminen pois käytöstä
            Ccontrol.enabled = false; //otetaan charactercontrolleri pois käytöstä
            _DeathText.enabled = true; //kuolemis teksti näytölle
            _yes.image.enabled = true; //kyllä nappi näytölle
            _no.image.enabled = true; //ei nappi näytölle
            _yestext.enabled = true; //kyllä teksti
            _notext.enabled = true; //ei teksti
            _yes.enabled = true;
            Cursor.lockState = CursorLockMode.None; // vapautetaan hiiren kursori
            Cursor.visible = true; // näytetään kursori
        }
    }
    public void Spawn() // kyllä nappin painamisen jälkeen
    {
        var Pmovement = pelaaja.GetComponent<PlayerMovement>();
        var Ccontrol = pelaaja.GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; //lukitaan kursori
        Cursor.visible = false; //piilotetaan hiiren kursori
        pelaaja.transform.position = spawn; //siirretään pelaaja alkuun
        Pmovement.enabled = true; //aktivoidaan liikkuminen
        Ccontrol.enabled = true; // character controllerin activoiminen
        _DeathText.enabled = false; //{
        _yes.image.enabled = false;
        _no.image.enabled = false; //piilotetaan kuolemisen yhteydessä näytölle avattu valikko
        _yestext.enabled = false;
        _notext.enabled = false;
        _yes.enabled = false; //}
    }
    public void Quit() //ei napin painamisen jälkeen
    {
        SceneManager.LoadScene("mainmenu"); //palataan alkunäyttöön
    }
}
