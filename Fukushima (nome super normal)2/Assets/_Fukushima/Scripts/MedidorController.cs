using UnityEngine;

public class MedidorController : MonoBehaviour
{
    [Header("Materiais")]
    public Material materialVemelho;
    public Material materialVerde;
    public Material materialAzul;
    public MeshRenderer renderer;
    [Header("Outros")]
    public float angulo;
    [Header("Objetos")]
    public Transform objetoAtual;
    public ObjetoFoco[] objetos;

    private int _objetoAtual;
    private float anguloAtual;
    
    private bool azul;

    void Start() 
    {
        AtualizaOjetos();
    }

    void Update()
    {   
        //SSSSUUUUUJJJOOOOO
        if(Input.GetKeyDown(KeyCode.K))
        {
            azul = azul ? false : true;
        }

        if(azul) renderer.material = materialAzul;
        else CalcularAngulo();
        //SSSSUUUUUJJJOOOO

        ChecarObjetos();
    }

    private void AtualizaOjetos() 
    {
        int _valor = 0;
        foreach (var _objeto in objetos)
        {
            _objeto.index = _valor;
            _valor++;
        } 
    }

    private void ChecarObjetos() 
    {
        foreach(var _objeto in objetos)
        {
            if(_objeto.index == _objetoAtual)
            {
                objetoAtual = _objeto.posicaoObjeto;
            }
        }
    }

    private void CalcularAngulo ()
    {
        Vector3 relative = transform.InverseTransformPoint(objetoAtual.position);
        anguloAtual = Mathf.Atan2(relative.x, relative.z) * Mathf.Rad2Deg;

        if (anguloAtual < angulo && anguloAtual > -angulo)
        {
            renderer.material = materialVerde;
        }    
        else 
        {
            renderer.material = materialVemelho;
        }    
    }

    private void ProximoObjeto() 
    {
        _objetoAtual++;
    }

    private void UltimoObjeto() 
    {
        _objetoAtual--;
    }
}


[System.Serializable]
public class ObjetoFoco 
{
    public Transform posicaoObjeto;
    public int index;
}
