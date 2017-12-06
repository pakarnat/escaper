using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryUIController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler{

    
    private InventoryDetails _inventoryDetails;
    private GameObject _playerInventoryWindow;    
    private GameObject _infoView;

    [SerializeField]
    private Text _infoText;

    [SerializeField]
    private GameObject _itemTemplate;
    private Transform _content;
    

    [SerializeField]
    private Transform rightHand;
    private bool isOver = false;

    private void Awake()
    {
        _playerInventoryWindow = transform.Find("Inventory_View").gameObject;
        _content = _playerInventoryWindow.transform.Find("Content");
        _infoView = transform.Find("Hint_View").gameObject;
        _inventoryDetails = transform.GetComponent<InventoryDetails>();
    }

    private void Start()
    {        
        for (int i = 0; i < _inventoryDetails.totalSlots; i++)
        {
            GameObject newItem = Instantiate(_itemTemplate, _content);
            newItem.transform.localScale = Vector3.one;            
        }

        for (int i = 0; i < _inventoryDetails.InventoryItems.Count; i++)
        {
            _content.GetChild(i).Find("ItemImage").GetComponent<Image>().sprite = _inventoryDetails.InventoryItems[i].gameObject.GetComponent<Item>().Sprite;
        }
        
    }    

    public void ToggleWindow(GameObject view)
    {
        view.SetActive(!view.activeSelf);
    }
    public void ShowInventory()
    {
        for (int i = 0; i < _inventoryDetails.InventoryItems.Count; i++)
        {
            _content.GetChild(i).Find("ItemImage").GetComponent<Image>().sprite = _inventoryDetails.InventoryItems[i].gameObject.GetComponent<Item>().Sprite;
        }

        ToggleWindow(_playerInventoryWindow);
    }
    public void OnPointerEnter(PointerEventData eventdata)
    {
        isOver = true;
        Debug.Log("Enter");
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        isOver = false;
        Debug.Log("Exit");
    }    
   
    public void OnItem(string itemName)
    {
        _infoText.text = "Pick up " + itemName + " with (E)";
        
        _infoView.SetActive(true); 
    }
    public void OffItem(bool staying)
    {
        _infoView.SetActive(false);
    }
    public void OnObject(string ObjectTag)
    {
        _infoText.text = "Open/close " + ObjectTag + "  with (E)";
        _infoView.SetActive(true);
    }
}
