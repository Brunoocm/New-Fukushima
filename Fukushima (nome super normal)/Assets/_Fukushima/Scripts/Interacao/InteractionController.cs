using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private InteractionInputData interactionInputData = null;
    [SerializeField] private InteractionData interactionData = null;

    [Header("Inventory Tudo")]
    public InventoryObject inventory;

    [Header("UI")]
    [SerializeField] private InteractionUIPanel uiPanel;
    [SerializeField] private Outline outline;

    [Header("Grab Tudo")]
    [SerializeField] private float rayDistance = 0f;
    [SerializeField] private float raySphereRadius = 0f;
    [SerializeField] private LayerMask interactableLayer = ~0;


    private Camera m_cam;

    private bool m_interacting;
    private bool m_onOutline;
    private float m_holdTimer = 0f;



    void Awake()
    {
        m_cam = FindObjectOfType<Camera>();
    }

    void Update()
    {
        CheckForInteractable();
        CheckForInteractableInput();

      
    }


    void CheckForInteractable()
    {
        Ray _ray = new Ray(m_cam.transform.position, m_cam.transform.forward);
        RaycastHit _hitInfo;

        bool _hitSomething = Physics.SphereCast(_ray, raySphereRadius, out _hitInfo, rayDistance, interactableLayer);

        if (_hitSomething) //se ta colidindo
        {
            InteractableBase _interactable = _hitInfo.transform.GetComponent<InteractableBase>();
            outline = _hitInfo.transform.GetComponent<Outline>();

            if (_interactable != null) //checar objeto e atualizar UI
            {
                if (interactionData.IsEmpty()) 
                {
                    
                    interactionData.Interactable = _interactable;
                    uiPanel.SetTooltip(_interactable.TooltipMessage);
                }
                else
                {
                    if (!interactionData.IsSameInteractable(_interactable)) //quando trocava de um objecto pro outro bugava
                    {
                        interactionData.Interactable = _interactable; //cria uma nova bool get set
                        uiPanel.SetTooltip(_interactable.TooltipMessage);//mesma coisa
                    }
                }
            }

            if(outline != null && !m_onOutline)
            {
                outline.enabled = true;
                m_onOutline = true;
            }

            



        }
        else
        {
            uiPanel.ResetUI();
            interactionData.ResetData(); //reseta qual objeto ta

            if(outline != null && m_onOutline)
            {
                outline.enabled = false;
                m_onOutline = false;
            }
            else if(outline == null)
            {
                m_onOutline = false;

            }

        }

    }

    void CheckForInteractableInput()
    {
        if (interactionData.IsEmpty())
            return;

        if (interactionInputData.InteractedClicked) //se clicou come�a contagem
        {
            m_interacting = true;
            m_holdTimer = 0f;
        }

        if (interactionInputData.InteractedReleased) //se solta o bot�o reseta a contagem
        {
            m_interacting = false;
            m_holdTimer = 0f;
            uiPanel.UpdateProgressBar(0f);
        }

        if (m_interacting)
        {

            if (interactionData.Interactable.HoldInteract) //come�a o timer de intera��o
            {               
                m_holdTimer += Time.deltaTime;

                float heldPercent = m_holdTimer / interactionData.Interactable.HoldDuration; // corrige para segundos
                uiPanel.UpdateProgressBar(heldPercent); //aplica os valores na UI

                if (heldPercent > 1f) //segurou tempo suficiente
                {
                    interactionData.Interact();
                    m_interacting = false;

                    m_holdTimer = 0f;
                    uiPanel.UpdateProgressBar(0f);
                }
            }
            else
            {
                interactionData.Interact(); //se nao puff
                m_interacting = false;
            }
        }
    }
}
