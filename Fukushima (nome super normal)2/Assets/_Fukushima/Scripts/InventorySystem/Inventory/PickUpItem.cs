using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : InteractableBase
{
    [Header("Inventory Data")]
    public InventoryObject inventory;
    public ItemObject item;
    public bool desbloqueiaLocal;
    
    private void Awake()
    {
        item.hasObjectItem = false;
    }
    public override void OnInteract()
    {
        base.OnInteract();

        if(item)
        {
            inventory.AddItem(item, 1);
            if(desbloqueiaLocal) FeedbackHandler.instance.Feedback(FeedbackHandler.feedbackType.NovoLocal, 3f);
            Destroy(gameObject, 0.3f);
            print(item.objectName);
        }

        if(base.HasMission)
        {
            GameObject obj = GameObject.Find("Mission Controller");
            obj.GetComponent<MissionContoller>().MissaoCompleta();
        }

    }

 
}
