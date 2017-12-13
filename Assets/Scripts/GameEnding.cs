using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour {

    public GameObject RescueBoat;

    private void OnTriggerEnter(Collider boatCol)
    {
        if (boatCol.tag == "RescueBoat")
        {
            SceneManager.LoadScene("mainmenu"); //palataan alkunäyttöön
        }

    }
}
