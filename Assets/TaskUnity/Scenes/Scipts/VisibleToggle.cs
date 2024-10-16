using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisibleToggle : MonoBehaviour
{
    public Toggle viewToggle;
    private Renderer _renderer;

    void Start()
    {
        viewToggle.isOn = true;    
    }

    public void setVisible(GameObject obj) 
    {
        if (obj == null) 
        {
            Debug.Log("Объект пустой для чекбокса");
        }
        Debug.Log("Не работает что-ли?");
        _renderer = obj.GetComponent<MeshRenderer>();
        _renderer.enabled = viewToggle.isOn;
    }
}
