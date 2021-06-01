using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBlocos : MonoBehaviour
{

    public MoveBlocos[] blocos;
    void Start()
    {
        
    }

    void Update()
    {
        print(BoolEscritorioMarido());
    
    }


    private bool BoolEscritorioMarido()
    {

        for (int i = 0; i < blocos.Length; i++)
        {

            if (blocos[i].gameObject.GetComponent<MoveBlocos>().isCorrect == false)
            {
                return false;

            }

        }
        return true;

    }
}
