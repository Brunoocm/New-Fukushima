using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class SlotPistas : MonoBehaviour, IPointerClickHandler
{
    public bool Acontecendo, Motivo, Assassino, isQuartel;


    [Header("Values")]
    public bool isSet;
    public bool correct;



    Image image;

    void Start()
    {
        image = gameObject.GetComponent<Image>();
    }

    void Update()
    {
        if(Motivo)
        {

        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        isSet = true;

        PistaMain[] pistaScripts = FindObjectsOfType(typeof(PistaMain)) as PistaMain[];

        for (int i = 0; i < pistaScripts.Length; i++)
        {

            if(pistaScripts[i].active)
            {
                image.sprite = pistaScripts[i].pistaImage.gameObject.GetComponent<Image>().sprite;

                if (pistaScripts[i].m_motivo && Motivo) correct = true;
                else if (pistaScripts[i].m_acontecendo && Acontecendo) correct = true;
                else if(pistaScripts[i].m_quartel && isQuartel) correct = true;
                else if(pistaScripts[i].m_assassino && Assassino) correct = true;
                else
                {
                    correct = false;
                }
              
            }
        }
       
        


    }

    public void Desativar()
    {
        isSet = false;

    }
}
