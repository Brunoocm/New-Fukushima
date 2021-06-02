using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainBlocos : MonoBehaviour
{

    public MoveBlocos[] blocos;

    [SerializeField] UnityEvent m_Event;

    void Start()
    {
        
    }

    void Update()
    {
        if(BoolEscritorioMarido())
        {
            MoveBlocos.cantMove = true;
            m_Event.Invoke();
        }
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
