using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveBlocos : MonoBehaviour
{
    public int numBloco;
    public int currentSlot;
    public bool hasCorrect;
    public bool isCorrect;

    private float mZCoord;
    private bool drag;
    private bool move;

    Vector3 mOffset;
    Vector3 currentPos;

    private void Update()
    {
        if(hasCorrect && numBloco == currentSlot)
        {
            isCorrect = true;
        }
    }

    void OnMouseDown()
    {

        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();

        currentPos = new Vector3(GetMouseAsWorldPoint().x + mOffset.x, GetMouseAsWorldPoint().y + mOffset.y, transform.position.z);
        move = true;

    }




    private Vector3 GetMouseAsWorldPoint()
    {

        Vector3 mousePoint = Input.mousePosition;

        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);

    }



    void OnMouseDrag()
    {
        
        if(move)transform.position = new Vector3(GetMouseAsWorldPoint().x + mOffset.x, GetMouseAsWorldPoint().y + mOffset.y, transform.position.z);
        drag = true;

    }

    private void OnMouseUpAsButton()
    {
        drag = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Blocos") || other.gameObject.CompareTag("ParedeBlocos"))
        {
            print("foi");
            if (drag)
            {
                drag = false;
                move = false;
                transform.position = currentPos;
            }
        }
    }

}
