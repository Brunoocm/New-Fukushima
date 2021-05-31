using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FerramentasInteractor : MonoBehaviour
{
    private readonly int defaultID = 1000;

    public int savedID;
    public Ferramenta savedFerramenta;

    private void Awake() 
    {
        savedID = defaultID;
    }

    public void InterageFerramenta(Ferramenta ferramenta)
    {
        if(savedID == defaultID)
        {
            savedID = ferramenta.ID;
            savedFerramenta = ferramenta;
        }   
        else 
        {
            savedFerramenta.AtivaFerramenta(ferramenta.ID);
            ferramenta.AtivaFerramenta(savedID);
            savedID = defaultID;
        }
    }
}
