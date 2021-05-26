using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    private float sensitivity;
    private float xRotation = 0f;

    public static bool click;

    public Transform playerBody;
    public GameObject maoCaderno;
   


    void Start()
    {
        sensitivity = mouseSensitivity;
        maoCaderno.SetActive(false);
    }

    void Update()
    {
        MouseMove();

        ChangeCursor();
    }

    void ChangeCursor()
    {
       
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            click = !click;
        }

        if (click) Cursor.lockState = CursorLockMode.Confined; 
        if (!click) Cursor.lockState = CursorLockMode.Locked; 

    }

    void MouseMove()
    {
        if (!click)
        {
            //float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            //float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            //xRotation -= mouseY;
            //xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            //transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            //playerBody.Rotate(Vector3.up * mouseX);

            maoCaderno.SetActive(false);
        }
        else
        {
            maoCaderno.SetActive(true);
        }
    }
}
