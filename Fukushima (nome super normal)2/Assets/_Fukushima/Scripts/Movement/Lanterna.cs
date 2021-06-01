using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanterna : MonoBehaviour
{
    public Light luz;
    public float intensidade;
    public GameObject objetoLigada;
    public GameObject objetoDesligada;

    [SerializeField] private bool ligada = true;

    private bool hudAtiva = true;
    
    private void Start() 
    {
        AtualizaHUD();
    }

    private void Update()
    {
        luz.intensity = ligada ? intensidade : 0;
        if(Input.GetKeyDown(KeyCode.F)) 
        {
            ligada = ligada ? false : true;
            AtualizaHUD();
        }
    }

    public void ligaDesligaHUD()
    {
        hudAtiva = hudAtiva ? false : true; 
        AtualizaHUD();
    }

    private void AtualizaHUD()
    {
        if(!hudAtiva) 
        {        
            objetoLigada.SetActive(false);
            objetoDesligada.SetActive(false);
            return;
        }

        if(ligada)
        {
            objetoLigada.SetActive(true);
            objetoDesligada.SetActive(false);
        }
        else 
        {
            objetoLigada.SetActive(false);
            objetoDesligada.SetActive(true);
        }

    }
}
