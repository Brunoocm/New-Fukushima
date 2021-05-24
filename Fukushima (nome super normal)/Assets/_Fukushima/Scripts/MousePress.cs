using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePress : MonoBehaviour
{
    public bool ponto;

    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if(ponto)
        {
            ponto = false;
            anim.SetTrigger("Normal");

        }
        else
        {
            ponto = true;
            anim.SetTrigger("Apertado");
        }
    }
}
