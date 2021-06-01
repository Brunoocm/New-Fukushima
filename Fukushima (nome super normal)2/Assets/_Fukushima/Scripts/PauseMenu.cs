using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool paused;

    public GameObject thisGameobject;
    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !paused)
        {
            PauseMenuVoid();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && paused)
        {
            Resume();
        }
    }
    void PauseMenuVoid()
    {
        Time.timeScale = 0;
        thisGameobject.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        paused = true;
    }
    public void Resume()
    {
        Time.timeScale = 1;
        thisGameobject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        paused = false;
    }
}
