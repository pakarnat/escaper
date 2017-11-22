using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private InventoryDetails _inventoryDetails;
    [SerializeField]
    private Canvas UI;
    private InventoryUIController _InvControl;

    private bool menuOpen;

    private bool inventoryOpen, playerJumped;
    public float speed = 6f;
    private float ogSpeed;
    public float sens = 4f;
    CharacterController player;    

    public GameObject eyes;
    Vector3 rayForward;
    RaycastHit hit;
    [SerializeField]
    private float rayReach;
    float rayDistance;
    int itemLayerMask;
    int interactableObjectLayerMask;

    public Transform rightHand;
    GameObject currentlyEquipped = null;

    private float moveFB; // FrontBack
    private float moveLR; // LeftRight

    private float rotX, rotY; // hiiren akselit

    private float vertVelocity;
    public float jumpVelocity = 20f;

    // Use this for initialization
    void Start () {

        _InvControl = UI.GetComponent<InventoryUIController>();
        player = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        menuOpen = false;
    }    

    // Update is called once per frame
    void Update () {

        itemLayerMask = LayerMask.GetMask("Item");
        interactableObjectLayerMask = LayerMask.GetMask("InteractableObject");
                               
        Movement(); 

        KeyController();                      
    }

    private void FixedUpdate()
    {
        Gravity();
        Raycast();
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
            rayForward = eyes.transform.TransformDirection(Vector3.forward) * rayReach;
            if (Physics.Raycast(eyes.transform.position, rayForward, out hit, rayReach, itemLayerMask))
            {
                PickUpItem(hit);
            }
            if(Physics.Raycast(eyes.transform.position, rayForward, out hit, rayReach, interactableObjectLayerMask))
            {
                InteractWithItem(hit);
            }
            
        }
        if (Input.GetButtonDown("Inventory")) // INVENTORY
        {
            if (inventoryOpen == false)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                inventoryOpen = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                inventoryOpen = false;
            }
            _InvControl.ShowInventory();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuOpen)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                menuOpen = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                menuOpen = true;
            }
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

    //Säde silmistä, jotta tiedetään mitä näkyy suoraan pelaajan edessä.
    private void Raycast()
    {                
        //Otetaan muuttujaan mistä, mihin suuntaan ja kuinka kauas halutaan säde ampua.
        rayForward = eyes.transform.TransformDirection(Vector3.forward) * rayReach;

        //Tämä on vain debugausta varten, että nähdään editorissa minne säde osuu.
        Debug.DrawRay(eyes.transform.position, rayForward, Color.yellow);

        //Ammutaan itse säde silmistä, out hit kertoo mihin on osuttu.
        if (Physics.Raycast(eyes.transform.position, rayForward, out hit, rayReach, itemLayerMask))
        {
            //Etsitään osutusta kohteesta componentti Item, siitä esineen nimi ja lähetään se UIsta huolta pitävälle scriptille.            
            _InvControl.OnItem(hit.collider.gameObject.GetComponent<Item>().Name);            
        }
        else
        {
            //Ei olla enää esineen päällä, UIsta huolta pitävän scriptin olisi hyvä tietää se.
            _InvControl.OffItem(false);
        } 
    }

    //Funktio itemeiden nostamiseen maasta.
    private void PickUpItem(RaycastHit hit)
    {
        //otetaan edessä oleva gameitem muuttujaan kiinni.
        GameObject item = hit.collider.gameObject;

        //Etsitään kyseisestä itemistä Itemdata luokka(scripti) ja laitetaan se muuttujaan.
        Item itemData = hit.collider.gameObject.GetComponent<Item>();

        //Tuhotaan pelimaailmassa oleva gameitem
        Destroy(item);

        //Luodaan uusi gameitem itemdatasta, jotta sen paikan, sijainnin saa otettua suoraan prefabista jotta se tulee oikeinpäin käteen
        //prefabit on siis oltava sellaisia joissa esine tulee oikeinpäin käteen. Tämän jälkeen vielä varmistetaan että uuden esineen isänä on oikea käsi.
        item = Instantiate(itemData.GameObjectPrefab, rightHand);         
        item.transform.SetParent(rightHand);        

        //Otetaan uuden, pelimaailmaan lisätyn itemin data käyttöön.
        itemData = item.GetComponent<Item>();
        itemData.PickedUp();

        //Jos kädessä ei ole vielä mitään, laitetaan esine käteen.
        if (currentlyEquipped == null) {
            
            itemData.Equip();
            currentlyEquipped = item;            
        }
        else
        {
            itemData.UnEquip();
        }

        //lisätään nostettu esine inventoryyn.
        _inventoryDetails.InventoryItems.Add(item);
        
    }
    private void InteractWithItem(RaycastHit hit)
    {
        GameObject obj = hit.collider.gameObject;
        //Do stuff with item. Eli obj on se gameitem, minkä kanssa haluaa jotain tehdä.
    }
}
