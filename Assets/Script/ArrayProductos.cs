using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrayProductos : MonoBehaviour
{
    public GameObject[] objetos; // Arreglo de objetos
    public int objetosIndex = 0; // Índice del objeto activo

    public void ActivarObjetoAleatorio()
    {
        objetosIndex = Random.Range(0, objetos.Length);
        DesactivarTodosLosObjetos();
        objetos[objetosIndex].SetActive(true);
    }

    void DesactivarTodosLosObjetos()
    {
        foreach (GameObject g in objetos)
        {
            g.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
