using System;
using UnityEngine;
using UnityEngine.AI;

public class ControllerCachorro : MonoBehaviour
{
    public bool debug;
    public GameObject debugBlock;

    [Header("Atributos")]
    public float velocidade;
    public float aceleracao;

    [Header("Controles")]
    public int pontoAtual;
    public WalkPoint[] pontos;

    private NavMeshAgent m_navMeshAgent;

    void Awake () 
    {
        m_navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        EnumerarPontos();

        m_navMeshAgent.speed = velocidade;
        m_navMeshAgent.acceleration = aceleracao;

        pontoAtual = 0;
        if(debug) debugBlock.SetActive(true);
        else debugBlock.SetActive(false);
    }

    void Update()
    {
        #if UNITY_EDITOR
            if(Input.GetKeyDown(KeyCode.M)) 
            {
                pontoAtual++; 
            }
            else if(Input.GetKeyDown(KeyCode.N)) 
            {
                pontoAtual--;
            }
        #endif

        foreach(WalkPoint _ponto in pontos) 
        {
            if(_ponto.numPonto == pontoAtual)  
            {
                m_navMeshAgent.SetDestination(_ponto.ponto.position);
                debugBlock.transform.position = _ponto.ponto.position;
                debugBlock.transform.position += new Vector3(0, 1, 0);
            }
        }


    }

    private void EnumerarPontos () 
    {
        int _ponto = 0;
        foreach (WalkPoint point in pontos) 
        {
            point.numPonto = _ponto;
            _ponto++;
        }  
    }

    public void ProximoPonto ()
    {
        pontoAtual++;
    }

    public void VoltaPonto () 
    {
        pontoAtual--;
    }
}

[Serializable]
public class WalkPoint 
{
    public Transform ponto;
    public int numPonto;
}
