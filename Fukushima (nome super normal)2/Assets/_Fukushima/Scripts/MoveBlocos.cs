using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlocos : MonoBehaviour
{


    private float mZCoord;
    private bool collides;

    private Vector3 mOffset;
    void OnMouseDown()
    {

        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();

    }



    private Vector3 GetMouseAsWorldPoint()
    {

        Vector3 mousePoint = Input.mousePosition;

        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);

    }



    void OnMouseDrag()
    {
        if (!collides)
        {
            transform.position = new Vector3(GetMouseAsWorldPoint().x + mOffset.x, GetMouseAsWorldPoint().y + mOffset.y, transform.position.z);
        }
    }

   

}
