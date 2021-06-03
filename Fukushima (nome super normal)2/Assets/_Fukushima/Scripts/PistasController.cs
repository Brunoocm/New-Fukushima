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

    public GameObject final1;
    public GameObject final2;
    public GameObject final3;

    private int valor;

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
        if(coletadas == 9) 
        {
            paginaPublicarMateria.SetActive(true);
            FeedbackHandler.instance.Feedback(FeedbackHandler.feedbackType.PublicarMateria);
        }
    } 

    public void Publicar()
    {

        valor = mainPistas.mainEscritorioDelegado ? valor += 1: valor += 0;
        valor = mainPistas.mainEscritorioMarido ? valor += 1: valor += 0;
        valor = mainPistas.mainCasa ? valor += 1: valor += 0;

        if(valor == 1)
        {
            final1.SetActive(true);

            final2.SetActive(false);
            final3.SetActive(false);
        }
        if(valor == 2)
        {
            final2.SetActive(true);

            final1.SetActive(false);
            final3.SetActive(false);


        }
        if (valor == 3)
        {
            final3.SetActive(true);

            final2.SetActive(false);
            final1.SetActive(false);
        }
    }
}