using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Notepad : MonoBehaviour
{
    [Header("Objetos")]
    public Transform container;
    public GameObject note;
    [Header("Input")]
    public TMP_InputField textInput;

    private string m_string;
    private TMP_Text m_tmpText;

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            CriaTexto();
        }
    }

    public void CriaTexto() 
    {
        // m_tmpText = container.transform.Find("Text (TMP)").GetComponent<TMP_Text>();
        // m_tmpText.text += textInput.text;

        m_string = textInput.text;
        textInput.text = "";

        GameObject m_newNote = Instantiate(note, transform.position, Quaternion.identity) as GameObject;
        m_newNote.transform.parent = container;
        m_newNote.transform.Find("Text (Note)").GetComponent<TMP_Text>().text = m_string;
    }
}
