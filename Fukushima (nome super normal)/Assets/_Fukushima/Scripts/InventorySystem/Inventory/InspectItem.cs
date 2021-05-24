using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class InspectItem : InteractableBase
{
    public InteractionUIPanel UIText;
    public VidUI UIvid;

    private Camera mainCam;

    private GameObject clickedObject;
    private GameObject fixPos;

    public VideoClip videoItem;

    Vector3 originaPosition;
    Vector3 originalRotation;

    private bool examineMode = false;
    private bool play = false;

    void Start()
    {
        mainCam = Camera.main;
        fixPos = GameObject.Find("InspectPos");

        //if (videoItem != null) Video Player;

    }

    private void Update()
    {
        TurnObject();

        ExitExamineMode();

        if ((UIvid.vid.frame) > 0 && (UIvid.vid.isPlaying == false))
        {      
            ExitVideo();
            
        }



    }



    void ClickObject()
    {
        if (!examineMode)
        {
            clickedObject = transform.gameObject;
            originaPosition = clickedObject.transform.position;
            originalRotation = clickedObject.transform.rotation.eulerAngles;
            clickedObject.transform.position = fixPos.transform.position;
            
            UIvid.SetVideo(videoItem);

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

            UIText.ResetUI();
        }

        if (Input.GetKeyDown(KeyCode.Q) && examineMode && !play)
        {
            UIvid.PlayVideo(); //play no video
            play = true;
        }


    }

    void ExitExamineMode()
    {
        if (Input.GetMouseButtonDown(1) && examineMode && !play)
        {
            Time.timeScale = 1;
            clickedObject.transform.position = originaPosition;
            clickedObject.transform.eulerAngles = originalRotation;

            UIvid.ResetObjects();
        
            examineMode = false;
        }
       
    }

    void ExitVideo()
    {
        if (base.HasMission)
        {
            GameObject obj = GameObject.Find("Mission Controller");
            obj.GetComponent<MissionContoller>().MissaoCompleta();
        }

        Time.timeScale = 1;
        clickedObject.transform.position = originaPosition;
        clickedObject.transform.eulerAngles = originalRotation;

        UIvid.ResetObjects();

        examineMode = false;
        play = false;
    }

    public override void OnInteract()
    {
        base.OnInteract();
        ClickObject();
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(0.1f);
        UIText.ResetUI();
    }
}
