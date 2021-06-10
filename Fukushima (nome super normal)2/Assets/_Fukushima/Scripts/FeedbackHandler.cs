using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackHandler : MonoBehaviour
{
    public Pista[] pistas;
    public static FeedbackHandler instance;
    public GameObject feedbackItem;

    private bool feedbackItemAtivo = false;

    public enum feedbackType
    {
        NovoLocal,
        NovaPista,
        PublicarMateria,
        TutorialItem,
    }

    private void Awake()
    {
        instance = this;
        feedbackItem.SetActive(false);
        
        foreach (Pista pista in pistas)
        {
            pista.pistaGameObject.SetActive(false);
        }
    }

    private void Update() 
    {
        foreach (Pista pista in pistas)
        {
            pista.timerPista = pista.timerPista >= 0 ? pista.timerPista -= Time.deltaTime : 0;
            pista.pistaAtiva = pista.timerPista != 0 ? true : false;
            pista.pistaGameObject.SetActive(pista.pistaAtiva);
        }
    }

    public void Feedback(feedbackType type, float feedbackduration)
    {
        foreach (Pista pista in pistas)
        {
            if(pista.tipoPista == type) pista.timerPista = feedbackduration;
        }
    }

    public void FeedbackItem()
    {
        feedbackItemAtivo = feedbackItemAtivo ? false : true;
        feedbackItem.SetActive(feedbackItemAtivo);
    }
}

[System.Serializable]
public class Pista 
{
    public string name;
    public GameObject pistaGameObject;
    public FeedbackHandler.feedbackType tipoPista;
    [HideInInspector] public bool pistaAtiva;
    [HideInInspector] public float timerPista;
}
