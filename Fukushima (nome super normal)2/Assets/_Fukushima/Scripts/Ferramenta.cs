using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ferramenta : MonoBehaviour
{
    public int ID;
    public ToolID[] ferramentas;
    public Transform myTransform => GetComponent<Transform>();

    private void Start()
    {
        AtualizaFerramentas();
        AtivaFerramenta(ID);
    }

    private void AtualizaFerramentas()
    {
        int currentID = 0;
        foreach (ToolID ferramenta in ferramentas)
        {
            ferramenta.ID = currentID;
            currentID++;
        }
    }

    public void AtivaFerramenta(int valor)
    {
        ID = valor;
        foreach (ToolID ferramenta in ferramentas)
        {  
            if(ferramenta.ID == ID) ferramenta.objeto.SetActive(true);
            else ferramenta.objeto.SetActive(false);
        }
    }
}

[Serializable]
public class ToolID
{
    public int ID;
    public GameObject objeto;
}