using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIController : MonoBehaviour {

    [SerializeField]
    private InventoryDetails _inventoryDetails;
    private GameObject _playerInventoryWindow;

    [SerializeField]
    private GameObject _itemTemplate;
    private Transform _content;   


    private void Awake()
    {
        _playerInventoryWindow = transform.Find("Inventory_View").gameObject;
        _content = _playerInventoryWindow.transform.Find("Content");
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

    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            for (int i = 0; i < _inventoryDetails.InventoryItems.Count; i++)
            {
                _content.GetChild(i).Find("ItemImage").GetComponent<Image>().sprite = _inventoryDetails.InventoryItems[i].Sprite;
            }
             

            ToggleWindow();

            //TO DO:
            //Toggle Mouselook!
        } 
        
    }

    public void ToggleWindow()
    {
        _playerInventoryWindow.SetActive(!_playerInventoryWindow.activeSelf);
    }

    

}
