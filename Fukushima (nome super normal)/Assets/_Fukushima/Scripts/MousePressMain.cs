using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePressMain : MonoBehaviour
{
    public bool oi;
    public bool[] resposta;

    public GameObject[] objects;

    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(TaCerto())
        {
            anim.SetTrigger("Abrir");
            print("foooi");
        }


    }

    private bool TaCerto()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            if (resposta[i] != objects[i].GetComponent<MousePress>().ponto)
            {
                return false;

            }
            else
            {

            }
        }
        return true;

    }
}
