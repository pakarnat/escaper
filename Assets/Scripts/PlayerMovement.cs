using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private InventoryDetails _inventoryDetails;
    [SerializeField]
    private Canvas UI;
    private InventoryUIController _InvControl;


    private bool inventoryOpen, playerJumped;
    public float speed = 6f;
    private float ogSpeed;
    public float sens = 4f;
    CharacterController player;    

    public GameObject eyes;
    Vector3 rayForward;
    RaycastHit hit;
    float rayDistance;
    int layerMask;

    public Transform rightHand;

    private float moveFB; // FrontBack
    private float moveLR; // LeftRight

    private float rotX, rotY; // hiiren akselit

    private float vertVelocity;
    public float jumpVelocity = 20f;

    // Use this for initialization
    void Start () {

        _InvControl = UI.GetComponent<InventoryUIController>();
        player = GetComponent<CharacterController>();        
        Cursor.visible = false;        
    }    

    // Update is called once per frame
    void Update () {

        layerMask = LayerMask.GetMask("Item");
        if (inventoryOpen == false)
        {                        
            Movement();
            Raycast();
        }

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
            rayForward = eyes.transform.TransformDirection(Vector3.forward) * 10;
            if (Physics.Raycast(eyes.transform.position, rayForward, out hit, 10, layerMask))
            {
                Item item = hit.collider.gameObject.GetComponent<Item>();
                _inventoryDetails.InventoryItems.Add(item);                
                Destroy(hit.collider.gameObject);                
            }
            
        }
        if (Input.GetButtonDown("Inventory")) // INVENTORY
        {
            if (inventoryOpen == false)
            {
                Cursor.visible = true;
                inventoryOpen = true;
            }
            else
            {
                Cursor.visible = false;
                inventoryOpen = false;
            }
            _InvControl.ShowInventory();
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

    private void Raycast()
    {                

        rayForward = eyes.transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(eyes.transform.position, rayForward, Color.yellow);

        if (Physics.Raycast(eyes.transform.position, rayForward, out hit, 10, layerMask))
        {
            Item item = hit.collider.gameObject.GetComponent<Item>();
            string itemName = item.Name;
            _InvControl.OnItem(itemName);
            Debug.Log(layerMask);
        }
        else
        {
            _InvControl.OffItem(false);
        }
        

        
    }    
}
