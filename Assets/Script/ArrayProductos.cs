using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrayProductos : MonoBehaviour
{
    public GameObject[] objetos; // Arreglo de objetos
    public int objetosIndex = 0; // Índice del objeto activo

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ActivateNextLight();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ActivatePreviousLight();
        }
    }

    public void ActivateNextLight()
    {
        objetosIndex++;
        if (objetosIndex >= objetos.Length)
        {
            objetosIndex = 0;
        }
        DeactivateAllLights();
        objetos[objetosIndex].SetActive(true);
    }

    public void ActivatePreviousLight()
    {
        objetosIndex--;
        if (objetosIndex < 0)
        {
            objetosIndex = objetos.Length - 1;
        }
        DeactivateAllLights();
        objetos[objetosIndex].SetActive(true);
    }

    void DeactivateAllLights()
    {
        foreach (GameObject g in objetos)
        {
            g.SetActive(false);
        }
    }


    public void ActivateRepeating(float t)
    {

    }
}
