using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private bool inventoryOpen, playerJumped;
    public float speed = 6f;
    private float ogSpeed;
    public float sens = 4f;
    CharacterController player;

    public GameObject eyes;

    private float moveFB; // FrontBack
    private float moveLR; // LeftRight

    private float rotX, rotY; // hiiren akselit

    private float vertVelocity;
    public float jumpVelocity = 20f;

    // Use this for initialization
    void Start () {

        player = GetComponent<CharacterController>();
        Cursor.visible = false;

	}
	
	// Update is called once per frame
	void Update () {

        Movement();

        KeyController();
        Gravity();
    }

    private void Movement()
    {
        moveFB = Input.GetAxis("Vertical") * speed;
        moveLR = Input.GetAxis("Horizontal") * speed;

        rotX = Input.GetAxis("Mouse X") * sens;
        rotY -= Input.GetAxis("Mouse Y") * sens;
        rotY = Mathf.Clamp(rotY, -60f, 60f);

        Vector3 movement = new Vector3(moveLR, vertVelocity, moveFB);

        transform.Rotate(0, rotX, 0);

        // eyes.transform.Rotate(-rotY, 0, 0);
        eyes.transform.localRotation = Quaternion.Euler(rotY, 0, 0);

        movement = transform.rotation * movement;

        player.Move(movement * Time.deltaTime);

    }

    private void KeyController()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ogSpeed = speed;
            speed = 40f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = ogSpeed;
        }
        // if (Input.GetKeyDown("space"))
        if (Input.GetButton("Jump"))
        {
            Jump();
        }

        if (Input.GetKeyDown("e"))
        {
            // Jos tavaran voi poimia, poimitaan tavara. Muuten ei tehdä mitään
            Debug.Log("Picks up item");
        }
        if (Input.GetKeyDown("i")) // INVENTORY
        {
            InventoryManagement();
        }

    }

    private void InventoryManagement()
    {
        inventoryOpen = true; // lopetetaan hiirellä kameran ohjaus ja tuodaan kursori tavaroiden käsittelyä varten
                              // Tähän inventoryn käsittely ja lopussa inventoryOpen = false;
                              // Kimmo jatkaa, ei taidot riitä

        if (inventoryOpen == true)
        {
            Cursor.visible = true;

        }

    }

    private void Jump()
    {
        playerJumped = true;
    }

    private void Gravity()
    {
        if (player.isGrounded == true)
        {
            if (playerJumped == false)
            {
                vertVelocity = Physics.gravity.y;
            }
            else
            {
                vertVelocity = jumpVelocity;
            }

        }
        else
        {
            vertVelocity += Physics.gravity.y * Time.deltaTime;
            vertVelocity = Mathf.Clamp(vertVelocity, -50f, jumpVelocity);
            playerJumped = false;
        }
    }
}
