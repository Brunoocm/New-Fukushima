using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePagina : MonoBehaviour
{
    public Transform pos;
    public int selectedItem = 0;

    public bool ativo;
    void Start()
    {
    }

    void Update()
    {
            SelectedItem();
            int previousSelectedItem = selectedItem;

        if (ativo)
        {
            if (Input.GetKeyDown(KeyCode.D))
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

            if (Input.GetKeyDown(KeyCode.A))
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




            if (previousSelectedItem != selectedItem)
            {
                SelectedItem();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                selectedItem = 0;
                ativo = false;

            }
        }
    }

    public void SelectedItem()
    {

        int i = 0;

        foreach (Transform itemS in pos.transform)
        {
            if (i == selectedItem)
            {

                itemS.gameObject.SetActive(true);

            }
            else
            {
                itemS.gameObject.SetActive(false);
            }
            i++;
        }

    }

    public void Ativar()
    {
        ativo = true;
    }

}
