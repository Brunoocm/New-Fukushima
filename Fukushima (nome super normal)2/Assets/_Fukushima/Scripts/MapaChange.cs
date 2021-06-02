using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapaChange : MonoBehaviour
{
    [Header("Mapa")]
    public Transform posQuarto;
    public Transform posEscritorio;
    public Transform posDelegacia;
    public Transform posEsconderijo;
    
    [SerializeField] GameObject quartoButton;
    [SerializeField] GameObject escritorioButton;
    [SerializeField] GameObject DelegadoButton;
    [SerializeField] GameObject EsconderijoButton;

    public ItemObject chave;
    public static bool delegaciaEnabled;
    public static bool esconderijoEnabled;

    [Header("Audio")]
    public AudioSource audioManager;
    public AudioClip quartoClip;
    public AudioClip escritorioClip;
    public AudioClip delegaciaClip;
    public AudioClip esconderijoClip;

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
        if (localName == "Escritorio"){ Escritorio(); audioManager.clip = escritorioClip; audioManager.Play(); }
        if (localName == "Casa") { Casa(); audioManager.clip = quartoClip; audioManager.Play(); }
        if (localName == "Delegacia") { Delegacia(); audioManager.clip = delegaciaClip; audioManager.Play(); }
        if (localName == "Esconderijo"){ Esconderijo(); audioManager.clip = esconderijoClip; audioManager.Play(); }
        else
        {

        }
    }

    public void LocalChange(string name)
    {
        localName = name;
    }
}
