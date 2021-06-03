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
    public AudioSource audioManagerMusicas;
    public AudioClip quartoClip;
    public AudioClip escritorioClip;
    public AudioClip delegaciaClip;
    public AudioClip esconderijoClip;
    public AudioClip trilhaQuarto;
    public AudioClip trilhaDelegacia;
    public AudioClip trilhaEsconderijo;
    public AudioClip trilhaEscritorio;

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

        if (esconderijoEnabled)
        {
            EsconderijoButton.gameObject.SetActive(true);

        }
        else
        {
            EsconderijoButton.gameObject.SetActive(false);
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

    public void SetTrueEsconderijo() 
    {
        esconderijoEnabled = true;
    }

    public void ViagemRapida()
    {
        if (localName == "Escritorio")
        {
            Escritorio(); 
            audioManager.clip = escritorioClip; 
            audioManagerMusicas.clip = trilhaEscritorio;
            audioManager.Play(); 
            audioManagerMusicas.Play();
        }
        if (localName == "Casa") 
        { 
            Casa(); 
            audioManager.clip = quartoClip; 
            audioManagerMusicas.clip = trilhaQuarto;
            audioManager.Play(); 
            audioManagerMusicas.Play();
        }
        if (localName == "Delegacia")
        {
            Delegacia(); 
            audioManager.clip = delegaciaClip; 
            audioManagerMusicas.clip = trilhaDelegacia;
            audioManager.Play(); 
            audioManagerMusicas.Play();
        }
        if (localName == "Esconderijo")
        {
            Esconderijo(); 
            audioManager.clip = esconderijoClip; 
            audioManagerMusicas.clip = trilhaEsconderijo;
            audioManager.Play(); 
            audioManagerMusicas.Play();
        }
        else
        {

        }
    }

    public void LocalChange(string name)
    {
        localName = name;
    }
}
