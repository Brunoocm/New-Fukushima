using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CodeBox : MonoBehaviour
{
    private int[] result, correctCombination;

    Animator anim;
    void Start()
    {
        result = new int[] { 1, 1, 1 };
        correctCombination = new int[] { 3, 1, 3 };
        CodeRotate.Rotated += CheckResults;

        anim = gameObject.GetComponent<Animator>();
    }

    void CheckResults(string wheelName, int number)
    {

        switch (wheelName)
        {
            case "PivotPuzzle":
                result[0] = number;
                break;
            case "PivotPuzzle2":
                result[1] = number;
                break;
            case "PivotPuzzle3":
                result[2] = number;
                break;
        }
        if(result[0] == correctCombination[0] && result[1] == correctCombination[1] && result[2] == correctCombination[2])
        {

            anim.SetTrigger("Open");
        }
    }

    private void OnDestroy()
    {
        CodeRotate.Rotated -= CheckResults;
    }
}
