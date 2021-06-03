using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackHandler : MonoBehaviour
{
    [SerializeField] private GameObject feedbackLocal;
    [SerializeField] private GameObject feedbackPista;
    [SerializeField] private GameObject feedbackPublicarMateria;

    public static FeedbackHandler instance;

    public enum feedbackType
    {
        NovoLocal,
        NovaPista,
        PublicarMateria,
    }

    private void Awake()
    {
        instance = this;
        
        feedbackPista.SetActive(false);
        feedbackLocal.SetActive(false);
        feedbackPublicarMateria.SetActive(false);
    }

    public void Feedback(feedbackType type)
    {
        if(type == feedbackType.NovaPista) feedbackPista.SetActive(true);
        else if(type == feedbackType.NovoLocal) feedbackLocal.SetActive(true);
        else if(type == feedbackType.PublicarMateria) feedbackPublicarMateria.SetActive(true);

        DesativarFeedbacks(); 
    }

    IEnumerator DesativarFeedbacks() 
    {
        yield return new WaitForSeconds(2.5f);
        feedbackPista.SetActive(false);
        feedbackLocal.SetActive(false);
        feedbackPublicarMateria.SetActive(false);
    }
}
