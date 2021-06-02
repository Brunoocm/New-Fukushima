using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapaChange : MonoBehaviour
{
    public Transform posQuarto;
    public Transform posEscritorio;
    public Transform posDelegacia;
    public Transform posEsconderijo;
    
    [SerializeField] GameObject quartoButton;
    [SerializeField] GameObject escritorioButton;
    [SerializeField] GameObject DelegadoButton;
    [SerializeField] GameObject EsconderijoButton;

    //[SerializeField] GameObject quarto;
    //[SerializeField] GameObject escritorio;
    //[SerializeField] GameObject Delegado;

    public ItemObject chave;
    public static bool delegaciaEnabled;
    public static bool esconderijoEnabled;

    private bool selected;
    private string localName;
    GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        print(delegaciaEnabled);
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
        player.transform.position = posQuarto.transform.position;
    }
    public void Delegacia()
    {
        player.transform.position = posDelegacia.transform.position;
    }
    public void Escritorio()
    {
        player.transform.position = posEscritorio.transform.position;
    }
    public void Esconderijo()
    {
        player.transform.position = posEsconderijo.transform.position;
    }

    public void setTrueDelegado()
    {
        delegaciaEnabled = true;
    }

    public void ViagemRapida()
    {
        if (localName == "Escritorio") Escritorio();
        if (localName == "Casa") Casa();
        if (localName == "Delegacia") Delegacia();
        if (localName == "Esconderijo") Esconderijo();
        else
        {

        }
    }

    public void LocalChange(string name)
    {
        localName = name;
    }
}
