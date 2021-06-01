using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBlocos : MonoBehaviour
{
    public int num;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnMouseUpAsButton()
    {
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Blocos"))
        {
            other.gameObject.GetComponent<MoveBlocos>().currentSlot = num;

        }
    }

}
