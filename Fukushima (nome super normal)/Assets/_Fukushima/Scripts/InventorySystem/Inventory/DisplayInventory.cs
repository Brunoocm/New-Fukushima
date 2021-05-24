using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;

    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
    void Start()
    {
        CreateDisplay();
    }

    void Update()
    {
        UpdateDisplay();

    }
    public void CreateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].item.objectName;
            obj.GetComponentInChildren<Image>().sprite = inventory.Container[i].item.objectSprite;
            obj.GetComponent<RectTransform>().localPosition = new Vector3(0,0,0);
            itemsDisplayed.Add(inventory.Container[i], obj);

        }
    }
    public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if(itemsDisplayed.ContainsKey(inventory.Container[i]))
            {

            }
            else
            {
                var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].item.objectName;
                obj.GetComponentInChildren<Image>().sprite = inventory.Container[i].item.objectSprite;
                obj.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
                itemsDisplayed.Add(inventory.Container[i], obj);
            }
        }
    }




 

}

