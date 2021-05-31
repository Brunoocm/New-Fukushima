using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PistasController : MonoBehaviour
{
    public GameObject[] pistasColetadas;
    public GameObject paginaPublicarMateria;
    public GameObject paginaPistasCorretas;
    public GameObject paginaPistasErradas;

    [SerializeField] private MainPistas mainPistas;

    private void Awake() 
    {
        pistasColetadas = new GameObject[9];
        paginaPublicarMateria.SetActive(false);
        paginaPistasErradas.SetActive(false);
        paginaPistasCorretas.SetActive(false);
    }

    public void PistaColetada(GameObject pista)
    {
        for(int i = 0; i < pistasColetadas.Length; i++)
        {
            if(pistasColetadas[i] == null)
            {
                pistasColetadas[i] = pista;
                ChecaPistas();
                return;
            }
        }
    }

    public void ChecaPistas() 
    {
        int coletadas = 0;
        foreach(GameObject _pista in pistasColetadas)
        {
            if(_pista != null) coletadas++;
        }
        if(coletadas == 9) paginaPublicarMateria.SetActive(true);
    } 

    public void Publicar()
    {
        if(mainPistas.mainEscritorioMarido && mainPistas.mainCasa && mainPistas.mainEscritorioDelegado)
        {
            paginaPublicarMateria.SetActive(false);
            paginaPistasCorretas.SetActive(true);
        }
        else 
        {
            paginaPublicarMateria.SetActive(false);
            paginaPistasErradas.SetActive(true);
        }
    }
}