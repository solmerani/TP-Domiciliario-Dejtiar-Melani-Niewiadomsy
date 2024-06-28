using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScriptJuego : MonoBehaviour
{
    public GameObject[] prefabsProductos;  // Array de prefabs de productos
    Vector3 positionProduct1 = new Vector3(-86, 48, 0);
    Vector3 positionProduct2 = new Vector3(-86, 48, 0);
    public Transform posicionProducto1;
    public Transform posicionProducto2;
    public Text precioProducto1;
    public Text precioProducto2;
    public float suma;
    public InputField inputResultado;
    public Text mensajeNotificacion;
    public Button botonResponder;
    public Button botonReiniciar;
    public Button botonSalir;
    public GameObject panelNotificacion;
    private int precio1;
    private int precio2;
    private GameObject instanciaProducto1;
    private GameObject instanciaProducto2;

    void Start()
    {
        GenerarNuevoDesafio();
        botonResponder.onClick.AddListener(Responder);
        botonReiniciar.onClick.AddListener(ReiniciarDesafio);
        botonSalir.onClick.AddListener(Salir);
    }

    void GenerarNuevoDesafio()
    {
        if (instanciaProducto1 != null)
        {
            Destroy(instanciaProducto1);
        }
        if (instanciaProducto2 != null)
        {
            Destroy(instanciaProducto2);
        }

        instanciaProducto1 = Instantiate(prefabsProductos[Random.Range(0, prefabsProductos.Length)], posicionProducto1.position, Quaternion.identity);
        instanciaProducto2 = Instantiate(prefabsProductos[Random.Range(0, prefabsProductos.Length)], posicionProducto2.position, Quaternion.identity);

        ProductoScript scriptProducto1 = instanciaProducto1.GetComponent<ProductoScript>();
        ProductoScript scriptProducto2 = instanciaProducto2.GetComponent<ProductoScript>();

        precio1 = scriptProducto1.precioproducto;
        precio2 = scriptProducto2.precioproducto;

        precioProducto1.text = GetComponent<ProductoScript>().precioproducto.ToString();
        precioProducto2.text = GetComponent<ProductoScript>().precioproducto.ToString();
        inputResultado.text = "";
        inputResultado.placeholder.GetComponent<Text>().text = "?";
        mensajeNotificacion.text = "";
        panelNotificacion.SetActive(false);
        botonResponder.GetComponentInChildren<Text>().text = "Responder";
    }

    void Responder()
    {
        if (string.IsNullOrEmpty(inputResultado.text))
        {
            mensajeNotificacion.text = "Debes ingresar un resultado";
            panelNotificacion.SetActive(true);
            return;
        }

        int resultadoUsuario;
        if (int.TryParse(inputResultado.text, out resultadoUsuario))
        {
            int resultadoCorrecto = precio1 + precio2;
            if (resultadoUsuario == resultadoCorrecto)
            {
                mensajeNotificacion.text = "¡Correcto!";
                botonResponder.GetComponentInChildren<Text>().text = "Reiniciar el desafío";
            }
            else
            {
                mensajeNotificacion.text = "Incorrecto. ¡Inténtalo de nuevo!";
                botonResponder.GetComponentInChildren<Text>().text = "Volver a intentarlo";
            }
        }
        else
        {
            mensajeNotificacion.text = "Debes ingresar un número válido";
        }

        panelNotificacion.SetActive(true);
    }

    void ReiniciarDesafio()
    {
        GenerarNuevoDesafio();
    }

    void Salir()
    {
        SceneManager.LoadScene("SeleccionarJuegos");
    }
}
