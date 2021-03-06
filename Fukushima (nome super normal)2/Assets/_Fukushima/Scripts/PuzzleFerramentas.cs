using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleFerramentas : MonoBehaviour
{
    public string ordemCorreta;
    public string ordemAtual;
    public bool puzzleCompleto;
    public Animator animator;

    public Ferramenta[] ferramentas = new Ferramenta[5];

    private void Awake()
    {
        puzzleCompleto = false;
    }

    private void Update()
    {
        ChecaResposta();
        if(puzzleCompleto)
        {
            animator.SetTrigger("Aberto");
        }
    }

    private void ChecaResposta()
    {
        ordemAtual = "";
        for (int i = 0; i < ferramentas.Length; i++)
        {
            ordemAtual += ferramentas[i].ID;
        }

        puzzleCompleto = ordemAtual == ordemCorreta ? true : false;
    }
}
