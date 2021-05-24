using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
 
    [SerializeField] private InteractionInputData interactionInputData = null;

    void Start()
    {
        interactionInputData.ResetInput();
    }

    void Update()
    {
        GetInteractionInputData();
    }

    void GetInteractionInputData()
    {
        interactionInputData.InteractedClicked = Input.GetKeyDown(KeyCode.E);
        interactionInputData.InteractedReleased = Input.GetKeyUp(KeyCode.E);
    }
}
