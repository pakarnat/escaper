using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorControl : MonoBehaviour {


    public float speed = 3;
    public float angle = 0;
    public Vector3 direction;

	// Use this for initialization
	void Start () {
        angle = transform.eulerAngles.y;
	}
	
	// Update is called once per frame
	void Update () {

        if (Mathf.Round(transform.eulerAngles.y) != angle)
        {
            transform.Rotate(direction * speed);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            angle = 90;
            direction = Vector3.up;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            angle = 0;
            direction = -Vector3.up;
        }
    }
}
