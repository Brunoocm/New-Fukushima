using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanterna : MonoBehaviour
{
    public Light luz;
    public float intensidade;
    public Color cor;
    public float innerSpotAngle;
    public float spotAngle;

    [SerializeField] private bool ligada;

    void Start()
    {
        //luz.intensity = 0;
    }

    void Update()
    {
        luz.intensity = ligada ? 0 : intensidade;
        if(Input.GetKeyDown(KeyCode.F)) ligada = ligada ? false : true;
 
        AtualizarLuz();
    }

    private void AtualizarLuz()  
    {
        //luz.color = cor;
        //luz.spotAngle = spotAngle;
        //luz.innerSpotAngle = innerSpotAngle;
    }
}
