using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "pista", menuName = "Inventory System/ Pista")]
public class ScriptablePistas : ScriptableObject
{  
    public string pistaName;
    [TextArea(10, 10)]
    public string description;

    public Sprite objectImage;
    public bool acontecendo, motivo, assassino, quartel;


}
