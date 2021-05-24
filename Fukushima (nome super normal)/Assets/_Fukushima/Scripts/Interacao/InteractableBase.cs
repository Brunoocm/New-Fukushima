using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableBase : MonoBehaviour
{
    [Header("Interactable Settings")]

    [SerializeField] private bool holdInteract = true;
    [SerializeField] private float holdDuration = 1f;

    [SerializeField] private bool isInteractable = true;
    [SerializeField] private bool hasMission = false;

    [SerializeField] private string tooltipMessage = "interact";

    public float HoldDuration => holdDuration;

    public bool HoldInteract => holdInteract;
    public bool IsInteractable => isInteractable;

    public bool HasMission => hasMission;
    public string TooltipMessage => tooltipMessage;


    public virtual void OnInteract()
    {
        //Debug.Log("AquiFoi: " + gameObject.name);
    }
    public virtual void Without()
    {
        Debug.Log("nao tem chave :( : " + gameObject.name);
    }
}
