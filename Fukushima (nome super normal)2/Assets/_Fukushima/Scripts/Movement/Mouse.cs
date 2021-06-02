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

    private bool oneTime;

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
       
        if(Input.GetKeyDown(KeyCode.Tab) && !PauseMenu.paused)
        {
            click = !click;
            if (click) Cursor.lockState = CursorLockMode.Confined; 

            if (!click) Cursor.lockState = CursorLockMode.Locked;

            oneTime = true;

        }


    }

    void MouseMove()
    {
        if (!click)
        {

            maoCaderno.SetActive(false);

            if(oneTime)
            {
                FindObjectOfType<AudioManager>().Play("LivroFechando");
         
                oneTime = false;
            }
        }
        else
        {
            maoCaderno.SetActive(true);



            if (oneTime)
            {
                FindObjectOfType<AudioManager>().Play("LivroAbrindo");

                oneTime = false;
            }
        }
    }
}
