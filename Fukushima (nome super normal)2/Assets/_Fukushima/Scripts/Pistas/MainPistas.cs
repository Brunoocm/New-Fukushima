    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPistas : MonoBehaviour
{
    [SerializeField] private Transform MissionEscritorioDelegado;
    [SerializeField] private Transform MissionQuartelG;
    [SerializeField] private Transform MissionEscritorioMarido;
    [SerializeField] private Transform MissionCasa;


    [SerializeField] private  GameObject[] escritorioDelegado;
    [SerializeField] private  GameObject[] quartelG;
    [SerializeField] private  GameObject[] escritorioMarido;
    [SerializeField] private  GameObject[] casa;

    [HideInInspector] public bool mainEscritorioMarido, mainEscritorioDelegado, mainQuartel, mainCasa;

    void Update()
    {
        Lugares();

        if(mainEscritorioMarido) print(mainEscritorioMarido);
        if(mainEscritorioDelegado) print(mainEscritorioDelegado);
        if(mainQuartel) print(mainQuartel);
        if(mainCasa) print(mainCasa);
 



    }

    void Lugares()
    {
        mainEscritorioMarido = BoolEscritorioMarido();
        mainEscritorioDelegado = BoolEscritorioDelegado();
        //mainQuartel = BoolQuartelG();
        mainCasa = BoolCasa();
    }

    private bool BoolEscritorioMarido()
    {
        escritorioMarido = new GameObject[MissionEscritorioMarido.transform.childCount];

        for (int i = 0; i < MissionEscritorioMarido.transform.childCount; i++)
        {
            escritorioMarido[i] = MissionEscritorioMarido.transform.GetChild(i).gameObject;

            if (escritorioMarido[i].gameObject.GetComponent<SlotPistas>().correct == false)
            {
                return false;

            }

        }
        return true;

    }
    private bool BoolEscritorioDelegado()
    {
        escritorioDelegado = new GameObject[MissionEscritorioDelegado.transform.childCount];

        for (int i = 0; i < MissionEscritorioDelegado.transform.childCount; i++)
        {
            escritorioDelegado[i] = MissionEscritorioDelegado.transform.GetChild(i).gameObject;

            if (escritorioDelegado[i].gameObject.GetComponent<SlotPistas>().correct == false)
            {
                return false;

            }

        }
        return true;

    }

    //private bool BoolQuartelG()
    //{
    //    quartelG = new GameObject[MissionQuartelG.transform.childCount];

    //    for (int i = 0; i < MissionQuartelG.transform.childCount; i++)
    //    {
    //        quartelG[i] = MissionQuartelG.transform.GetChild(i).gameObject;

    //        if (quartelG[i].gameObject.GetComponent<SlotPistas>().correct == false)
    //        {
    //            return false;

    //        }

    //    }
    //    return true;

    //}
    private bool BoolCasa()
    {
        casa = new GameObject[MissionCasa.transform.childCount];

        for (int i = 0; i < MissionCasa.transform.childCount; i++)
        {
            casa[i] = MissionCasa.transform.GetChild(i).gameObject;

            if (casa[i].gameObject.GetComponent<SlotPistas>().correct == false)
            {
                return false;

            }

        }
        return true;

    }

}

