using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class doorscipt : MonoBehaviour {

	// Use this for initialization
	

    public bool open;
    public bool close;
    [SerializeField]
    private GameObject RescueBoat;
    [SerializeField]
    int BoatSpeed;
    public bool end = false;
    private bool played = false;
    [SerializeField]
    private GameObject Majakanvalo;
    [SerializeField]
    private int RotationSpeed;

    public Camera mainCamera;
    public Camera itemCamera;
    public Camera EndCamera;
    public Image crosshair;
    public GameObject hintView;
    public GameObject Player;

    
    void Update()
    {
        if (end)
        {
            EndGame();
        }
   

        if (open)
        {
            var newRot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, 130.0f, 0.0f), Time.deltaTime * 200);
            transform.rotation = newRot;
            end = true;
            EndCamera.enabled = true;
            mainCamera.enabled = itemCamera.enabled = false;
            crosshair.enabled = false;            
        }
        else
        {
            


            var newRot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, 45.0f, 0.0f), Time.deltaTime * 200);
            transform.rotation = newRot;
        }
        if(open && !played)
        {
            Player.SetActive(false);
            hintView.SetActive(false);
            EndCamera.GetComponent<Animation>().Play();
            Majakanvalo.GetComponentInChildren<Lighthouse>().EnableLights();
            played = true;
        }
    }

    void EndGame()
    {        
        RescueBoat.transform.position += RescueBoat.transform.forward * BoatSpeed * Time.deltaTime;                
        Majakanvalo.transform.Rotate(Vector3.up * RotationSpeed * Time.deltaTime);
    }
}
