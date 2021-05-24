using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventsObject : InteractableBase
{
    [SerializeField] private UnityEvent m_Event;

    public AudioClip clipTrilha;

    private void Start()
    {
    }

    public void Update()
    {
    }

    public override void OnInteract()
    {

        m_Event.Invoke();
    }


    public void AudioTroca()
    {
        GetComponent<AudioSource>().clip = clipTrilha;
    }

}
