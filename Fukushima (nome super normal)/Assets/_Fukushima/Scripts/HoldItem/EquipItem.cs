using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipItem : MonoBehaviour
{
    [Header("Data")]
    public InventoryObject inventory;
    public InventoryScroll invScroll;

    [Header("Objects")]

    public Transform right;
    public Transform left;

    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();


    void Start()
    {
        
    }

    void Update()
    {
        SpawnItem();
    }


    void SpawnItem()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(inventory.Container[i]))
            {

            }
            else
            {
                var obj = Instantiate(inventory.Container[i].item.prefabModel, right.transform);

                itemsDisplayed.Add(inventory.Container[i], obj);
            }

        }

    }
    
}
