using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CodeRotate : MonoBehaviour
{
    public static event Action<string, int> Rotated = delegate { };

    private bool coroutineAllowed;

    private int numberShown = 1;

    //private int number;
    void Start()
    {
        coroutineAllowed = true;
        
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if(coroutineAllowed)
        {
            StartCoroutine(RotateWheel());
        }

        

        //if (number < 2)
        //{
        //    transform.Rotate(0f, 0f, -90f);
        //    number++;
        //}
        //else
        //{
        //    transform.Rotate(0f, 0f, 180f);
        //    number = 0;
        //}
    }

    IEnumerator RotateWheel()
    {
        coroutineAllowed = false;

        for (int i = 0; i < 3; i++)
        {
            transform.Rotate(0f, 0f, 90f);
            yield return new WaitForSeconds(0.01f);
        }

        //for (int i = 0; i > 2; i++)
        //{
        //    transform.Rotate(0f, 0f, 180f);
        //    yield return new WaitForSeconds(0.01f);
        //}

        coroutineAllowed = true;

        numberShown++;

        if(numberShown > 3)
        {
            numberShown = 0;
        }

        Rotated(name, numberShown);
    }

}
