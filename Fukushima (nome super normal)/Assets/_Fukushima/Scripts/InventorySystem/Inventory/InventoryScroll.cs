using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScroll : MonoBehaviour
{
    public InventoryObject inventory;
    public Transform pos;
    public int selectedItem = 0;
    void Start()
    {
    }

    void Update()
    {
        SelectedItem();
        int previousSelectedItem = selectedItem;

        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedItem >= pos.transform.childCount - 1)
            {
                selectedItem = 0;
            }
            else
            {
                selectedItem++;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedItem <= 0)
            {
                selectedItem = pos.transform.childCount - 1;
            }
            else
            {
                selectedItem--;
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedItem = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && pos.transform.childCount >= 2)
        {
            selectedItem = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && pos.transform.childCount >= 3)
        {
            selectedItem = 2;
        }



        if (previousSelectedItem != selectedItem)
        {
            SelectedItem();
        }
    }

    public void SelectedItem()
    {
        
        int i = 0;
    
        foreach (Transform itemS in pos.transform)
        {
            if(i == selectedItem)
            {

                itemS.gameObject.SetActive(true);
                inventory.Container[i].item.hasObjectItem = true;

            }
            else
            {
                itemS.gameObject.SetActive(false);
                inventory.Container[i].item.hasObjectItem = false;
            }
            i++;
        }
       
    }

    private void OnApplicationQuit()
    {
        //inventory.Container.All<>.item.hasObjectItem = false;
        //inventory.Container.Any(c => c = true);
        inventory.Container.Clear();    

    }
}
