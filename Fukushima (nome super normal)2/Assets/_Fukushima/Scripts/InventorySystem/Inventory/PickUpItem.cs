using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : InteractableBase
{
    [Header("Inventory Data")]
    public InventoryObject inventory;
    public ItemObject item;
    
    private void Start()
    {
        item.hasObjectItem = false;
    }
    public override void OnInteract()
    {
        base.OnInteract();

        if(item)
        {
            inventory.AddItem(item, 1);
            Destroy(gameObject);
            print(item.objectName);
        }

        if(base.HasMission)
        {
            GameObject obj = GameObject.Find("Mission Controller");
            obj.GetComponent<MissionContoller>().MissaoCompleta();
        }

    }

 
}
