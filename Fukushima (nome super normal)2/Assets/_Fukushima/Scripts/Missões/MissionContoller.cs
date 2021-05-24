using System;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class MissionContoller : MonoBehaviour
{
    [Header("Geral")]
    public TMP_Text missionNameText;
    public TMP_Text missionText;
    public string missaoAtual;
    [Header(" ")]
   
    public Mission[] missoes;
    [Header("Animator")]
    public Animator anim;

    private int _missaoAtual;

    private bool eventOff;

    void Start()
    {
        EnumerarMissoes();
        anim.SetTrigger("Ativar");
        _missaoAtual = 0;
    }

    // Update is called once per frame
    void Update()
    {
        #if UNITY_EDITOR
            if(Input.GetKeyDown(KeyCode.P))
            {
                MissaoCompleta();
            }
        #endif

        ChecarMissoes();
    }

    private void EnumerarMissoes () 
    {
        int _missionID = 0;
        foreach (Mission missao in missoes) 
        {
            missao.missionID = _missionID;
            _missionID++;
        }  
    }

    private void ChecarMissoes () 
    {
        foreach(Mission missao in missoes) 
        {
            if(missao.missionID == _missaoAtual)
            {
                missaoAtual = missao.missionName;
                missao.active = true;
                missionNameText.text = missao.missionName;
                missionText.text = missao.missionText;
                if(missao.Event != null  && !eventOff) 
                {
                    missao.Event.Invoke();
                    eventOff = true;
                }
            }
            else 
            {
                missao.active = false;
                if(missao.missionID < _missaoAtual) 
                {
                    missao.complete = true;
                }
            }
        }

        if(_missaoAtual >= missoes.Length) 
        {
            missionNameText.text = "Todas as missões completas!";
        }
    }

    public void MissaoCompleta () 
    {
        _missaoAtual++;

        anim.SetTrigger("Ativar");

        eventOff = false;
    }
}

[Serializable]
public class Mission 
{
    public bool active;
    public string missionName;
    public int missionID;
    [TextArea]
    public string missionText;
    public bool complete;
    public UnityEvent Event;
}
