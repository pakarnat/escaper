using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryUIController : MonoBehaviour {

    [SerializeField]
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
    }

    private void Start()
    {
        _inventoryDetails.InventoryItems.Clear();
        for (int i = 0; i < _inventoryDetails.TotalSlots; i++)
        {
            GameObject newItem = Instantiate(_itemTemplate, _content);
            newItem.transform.localScale = Vector3.one;
        }

        for (int i = 0; i < _inventoryDetails.InventoryItems.Count; i++)
        {
            _content.GetChild(i).Find("ItemImage").GetComponent<Image>().sprite = _inventoryDetails.InventoryItems[i].Sprite;
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
            _content.GetChild(i).Find("ItemImage").GetComponent<Image>().sprite = _inventoryDetails.InventoryItems[i].Sprite;
        }

        ToggleWindow(_playerInventoryWindow);
    }
    public void EquipItem()
    {

    }
    public void OnItem(string itemName)
    {        
        _infoText.text = "Pick up " + itemName + " with e";
        _infoView.SetActive(true); 
    }
    public void OffItem(bool staying)
    {
        _infoView.SetActive(false);
    }

    
    

    

}
