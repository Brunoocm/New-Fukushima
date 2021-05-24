using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerMission : MonoBehaviour
{
    public MissionContoller mission;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            mission.MissaoCompleta();
            Destroy(gameObject);
        }

    }
}
