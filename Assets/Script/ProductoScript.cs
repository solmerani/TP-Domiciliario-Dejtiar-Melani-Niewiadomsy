using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductoScript : MonoBehaviour
{
    public int precioproducto;
    public GameObject[] Arrayproductos;
    Vector3 posicionPrimerProducto = new Vector3(-100, 60, 0);
    Vector4 posicionSegundoProducto = new Vector4(110f, 60, 0);

    public Text PrecioProducto1;
    public Text PrecioProducto2;
    public InputField InputPrecio;
    private int suma;
    public Text Notificaciondeltexto;
    public GameObject panelmain;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
