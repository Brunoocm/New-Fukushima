using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class PistaMain : MonoBehaviour, IPointerClickHandler
{

    public bool active;
    public ScriptablePistas pista;
    public GameObject pistaImage;

    private bool m_active;
    private string m_pistaName;
    public bool m_motivo, m_acontecendo, m_quartel, m_assassino;



    [SerializeField] GameObject[] objDescription;
    [SerializeField] TMP_Text[] textDescription;
    [SerializeField] Image[] imageDescription;

    private void Start()
    {
        m_motivo = pista.motivo;
        m_acontecendo = pista.acontecendo;
        m_quartel = pista.quartel;
        m_assassino = pista.assassino;

        if (objDescription != null) 
        { 
            objDescription = GameObject.FindGameObjectsWithTag("DescriptionTag");
            textDescription = new TMP_Text[objDescription.Length];
            imageDescription = new Image[objDescription.Length]; 
        }


        for (int i = 0; i < objDescription.Length; i++)
        {
            textDescription[i] = objDescription[i].GetComponentInChildren<TMP_Text>();
            imageDescription[i] = objDescription[i].GetComponentInChildren<Image>();
            
        }
        pistaImage.GetComponent<Image>().sprite = pista.objectImage;
        m_pistaName = pista.pistaName;
    }


    void Update()
    {
        active = m_active;
       
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        PistaMain[] pistaScripts = FindObjectsOfType(typeof(PistaMain)) as PistaMain[];

        for (int i = 0; i < pistaScripts.Length; i++)
        {
            pistaScripts[i].m_active = false;
        }

        m_active = true;
        SetDescription();
    }

    void SetDescription()
    {
        for (int i = 0; i < textDescription.Length; i++)
        {
            textDescription[i].text = pista.description;
        }
        for (int j = 0; j < imageDescription.Length; j++)
        {
            imageDescription[j].sprite = pista.objectImage;
        }
    }
}
