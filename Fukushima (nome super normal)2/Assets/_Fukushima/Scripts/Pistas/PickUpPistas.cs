using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;


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
    private PistasController pistasController;

    Vector3 originaPosition;
    Vector3 originalRotation;

    [TextArea] public string[] playerFala;
    private int index = 0;
    private bool set;
    private float timerFala;
    Image FundoText;
    TextMeshProUGUI TextForPistas;

    [SerializeField] UnityEvent m_MyEvent;

    private void Start()
    {
        pistaScript = FindObjectOfType<PistasSpawn>();
        pistasController = FindObjectOfType<PistasController>();
        FundoText = GameObject.Find("TextForPistas").GetComponentInChildren<Image>();
        TextForPistas = GameObject.Find("TextForPistas").GetComponentInChildren<TextMeshProUGUI>();

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

        timer();
    }

    void Spawn()
    {
        if (!umaVez)
        {
            for (int i = 0; i < pistaScript.pistasPivotSpawner.Length; i++)
            {
                GameObject spawn = Instantiate(prefabPistas, pistaScript.pistasPivotSpawner[i].transform.position, pistaScript.pistasPivotSpawner[i].transform.rotation);
                spawn.transform.parent = pistaScript.pistasPivotSpawner[i].transform;

                StartCoroutine(TrueVoid());

                m_MyEvent.Invoke();
            }
            pistasController.PistaColetada(prefabPistas);
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

            FirstPersonController.turnCamera = true;

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
            clickedObject.transform.Rotate(Vector3.forward, yAxis, Space.World);

            UIText.ResetUI();
        }

        if (examineMode)
        {
            float scroll = 0.02f;

            if (Input.GetAxisRaw("Mouse ScrollWheel") > 0 && fixPos.transform.localPosition.z <= 0.6f)
            {

                clickedObject.transform.position = fixPos.transform.position;
                fixPos.transform.Translate(0, 0, scroll);
                UIText.ResetUI();
            }
            if (Input.GetAxisRaw("Mouse ScrollWheel") < 0 && fixPos.transform.localPosition.z >= 0.15f)
            {

                clickedObject.transform.position = fixPos.transform.position;
                fixPos.transform.Translate(0, 0, -scroll);
                UIText.ResetUI();
            }
        }

    }

    void ExitExamineMode()
    {
        if (Input.GetMouseButtonDown(1) && examineMode)
        {
            Time.timeScale = 1;
            clickedObject.transform.position = originaPosition;
            clickedObject.transform.eulerAngles = originalRotation;

            FirstPersonController.turnCamera = false;

            examineMode = false;
        }

    }

    IEnumerator TrueVoid()
    {
        yield return new WaitForSeconds(0.5f);
        set = true;

    }

    void timer()
    {
        int num = playerFala.Length;

        if (set)
        {
            if (index < num && timerFala <= 0)
            {
                TextForPistas.text = playerFala[index];
                FundoText.enabled = true;
                timerFala = 5;


                index++;


            }
            else if (index == num && timerFala <= 0)
            {
                set = false;
                TextForPistas.text = "";
                FundoText.enabled = false;
            }

            timerFala -= Time.deltaTime;
        }


    }

}
