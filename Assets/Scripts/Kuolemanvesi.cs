using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Kuolemanvesi : MonoBehaviour {
    public GameObject pelaaja;
    Vector3 spawn =  new Vector3(3190, 48, 3070);
    [SerializeField]
    private Text _DeathText;
    [SerializeField]
    private Button _yes;
    [SerializeField]
    private Button _no;
    [SerializeField]
    private Text _yestext;
    [SerializeField]
    private Text _notext;
    // Use this for initialization

    void OnTriggerEnter(Collider other)
    {
        var Pmovement = pelaaja.GetComponent<PlayerMovement>();
        var Ccontrol = pelaaja.GetComponent<CharacterController>();
        Pmovement.enabled = false;
        Ccontrol.enabled = false;
        _DeathText.enabled = true;
        _yes.image.enabled = true;
        _no.image.enabled = true;
        _yestext.enabled = true;
        _notext.enabled = true;
        _yes.enabled = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void Spawn()
    {
        var Pmovement = pelaaja.GetComponent<PlayerMovement>();
        var Ccontrol = pelaaja.GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pelaaja.transform.position = spawn;
        Pmovement.enabled = true;
        Ccontrol.enabled = true;
        _DeathText.enabled = false;
        _yes.image.enabled = false;
        _no.image.enabled = false;
        _yestext.enabled = false;
        _notext.enabled = false;
        _yes.enabled = false;
        Debug.Log("Click");
    }
    public void Quit()
    {
        SceneManager.LoadScene("mainmenu");
    }
}
