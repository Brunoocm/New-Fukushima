using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPistas : InteractableBase
{

    [Header("Inventory Data")]
    public GameObject prefabPistas;
    public InteractionUIPanel UIText;


    private Camera mainCam;

    private GameObject clickedObject;
    private GameObject fixPos;
    private bool examineMode = false;
    private bool umaVez;
    private PistasSpawn pistaScript;

    Vector3 originaPosition;
    Vector3 originalRotation;

    private void Start()
    {
        pistaScript = FindObjectOfType<PistasSpawn>();

        mainCam = Camera.main;
        fixPos = GameObject.Find("InspectPos");
    }
    public override void OnInteract()
    {
        base.OnInteract();
        Spawn();
        ClickObject();

        if (base.HasMission)
        {
            GameObject obj = GameObject.Find("Mission Controller");
            obj.GetComponent<MissionContoller>().MissaoCompleta();
        }
    }

    private void Update()
    {
        TurnObject();

        ExitExamineMode();
    }

    void Spawn()
    {
        if (!umaVez)
        {
            for (int i = 0; i < pistaScript.pistasPivotSpawner.Length; i++)
            {
                GameObject spawn = Instantiate(prefabPistas, pistaScript.pistasPivotSpawner[i].transform.position, pistaScript.pistasPivotSpawner[i].transform.rotation);
                spawn.transform.parent = pistaScript.pistasPivotSpawner[i].transform;

            }
            umaVez = true;
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

}
