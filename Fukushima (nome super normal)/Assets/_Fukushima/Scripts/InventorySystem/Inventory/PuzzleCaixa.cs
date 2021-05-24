using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PuzzleCaixa : InteractableBase
{
    private GameObject clickedObject;
    private GameObject fixPos;

    Vector3 originaPosition;
    Vector3 originalRotation;

    private bool examineMode;

    void Start()
    {
        fixPos = GameObject.Find("InspectPos");
        examineMode = false;

        //if (videoItem != null) Video Player;

    }

    private void Update()
    {
        TurnObject();

        ExitExamineMode();

        //if (!examineMode)
        //{
        //    Time.timeScale = 1;
        //}
    }



    void ClickObject()
    {
        if (!examineMode)
        {
            clickedObject = transform.gameObject;
            originaPosition = clickedObject.transform.position;
            originalRotation = clickedObject.transform.rotation.eulerAngles;
            clickedObject.transform.position = fixPos.transform.position;
            

            Time.timeScale = 0;

            examineMode = true;
            
        }

    }

    void TurnObject()
    {
        if (Input.GetMouseButton(0) && examineMode)
        {         
            float rotationSpeed = 15;

            float xAxis = Input.GetAxis("Mouse X") * rotationSpeed;
            float yAxis = Input.GetAxis("Mouse Y") * rotationSpeed;

            clickedObject.transform.Rotate(Vector3.up, -xAxis, Space.World);
            clickedObject.transform.Rotate(Vector3.right, yAxis, Space.World);
        }

    }

    void ExitExamineMode()
    {
        if (Input.GetMouseButtonDown(1) && examineMode)
        {
            Time.timeScale = 1;
            clickedObject.transform.position = originaPosition;
            clickedObject.transform.eulerAngles = originalRotation;
            
            examineMode = false;
        }
    }

    public override void OnInteract()
    {
        base.OnInteract();
        ClickObject();
    }

}
