using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapaChange : MonoBehaviour, IPointerDownHandler
{
    public Transform posQuarto;
    public Transform posEscritorio;
    public Transform posDelegacia;
    
    [SerializeField] GameObject quartoButton;
    [SerializeField] GameObject escritorioButton;
    [SerializeField] GameObject DelegadoButton;

    [SerializeField] GameObject quarto;
    [SerializeField] GameObject escritorio;
    [SerializeField] GameObject Delegado;

    public ItemObject chave;
    public static bool delegaciaEnabled;

    private bool selected;
    private string localName;
    GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (chave.hasObjectItem)
        {
            escritorioButton.gameObject.SetActive(true);
        }
        else
        {
            escritorioButton.gameObject.SetActive(false);

        }

        if (delegaciaEnabled)
        {
            DelegadoButton.gameObject.SetActive(true);

        }
        else
        {
            DelegadoButton.gameObject.SetActive(false);

        }
    }

    public void Casa()
    {
        //quarto.SetActive(true);
        //escritorio.SetActive(false);
        //Delegado.SetActive(false);

        player.transform.position = posQuarto.transform.position;


    }
    public void Delegacia()
    {
        //quarto.SetActive(false);
        //Delegado.SetActive(true);
        //escritorio.SetActive(false);

        player.transform.position = posDelegacia.transform.position;



    }
    public void Escritorio()
    {
        //quarto.SetActive(false);
        //Delegado.SetActive(false);
        //escritorio.SetActive(true);

        player.transform.position = posEscritorio.transform.position;


    }

    public void setTrueDelegado()
    {
        delegaciaEnabled = true;

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (localName == "Escritorio") Escritorio();
        if (localName == "Casa") Casa();
        if (localName == "Delegacia") Delegacia();
        else
        {

        }
    }

    public void LocalChange(string name)
    {
        localName = name;
    }
}
