using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScriptJuego : MonoBehaviour
{
    public GameObject[] ArrayProducto1;
    public GameObject[] ArrayProducto2; // Array de prefabs de productos
    public Text TextoSuma;
    public Text TxtPrecio1;
    public Text TxtPrecio2;
    public InputField InputFieldsuma;
    public GameObject respuesta;
    public GameObject respuestaCorrecta;
    public GameObject respuestaIncorrecta;
    public Text textoNotificacion;
    public Button botonReintentar;
    public Button botonSalir;
    public GameObject panelNotificaciones;
    int precio1;
    int precio2;
    int Precio1;
    int Precio2;

    void Start()
    {
        DeactivateAll();
        Activate();
        panelNotificaciones.SetActive(false);
    }
    void DeactivateAll()
    {
        foreach (GameObject g1 in ArrayProducto1)
        {
            g1.SetActive(false);
        }
        foreach (GameObject g2 in ArrayProducto2)
        {

            g2.SetActive(false); }
    }
    void Activate()
    {
       

        precio1 = Random.Range(0, ArrayProducto1.Length);
        precio2 = Random.Range(0, ArrayProducto2.Length);
        ArrayProducto1[precio1].transform.position = new Vector3(-112f, 0f, 0f);
        ArrayProducto2[precio2].transform.position = new Vector3(112f, 0f, 0f);
        ArrayProducto1[precio1].SetActive(true);
        ArrayProducto2[precio2].SetActive(true);
        Precio1 = ArrayProducto1[precio1].GetComponent<ProductoScript>().precioproducto;
        Precio2 = ArrayProducto2[precio2].GetComponent<ProductoScript>().precioproducto;
        Debug.Log("Precio1: " + Precio1 + " Precio2:  " + Precio2);
        TxtPrecio1.text = "$" + Precio1.ToString();
        TxtPrecio2.text = "$" + Precio2.ToString();
        Debug.Log(gameObject.name);

    }
    public void BotonResponderOnClick()
    {
        Debug.Log("Boton Responder Presionado");
        string respuestausuarioText = InputFieldsuma.text;
        int numeroIngreso = int.Parse(respuestausuarioText);
        Debug.Log("Texto de respuesta: " + numeroIngreso);
      

        if (string.IsNullOrEmpty(respuestausuarioText))
        {
            Debug.Log("Respuesta esta vacia");
            respuestaCorrecta.SetActive(false);
            respuestaIncorrecta.SetActive(false);
            

        }
        else
        {
            int preciototalsuma = Precio1 + Precio2;
            Debug.Log("Respuesta del usuario" + numeroIngreso);
            if (numeroIngreso == preciototalsuma)
            {
                Debug.Log("respuesta correcta");
                respuestaCorrecta.SetActive(true);
                respuestaIncorrecta.SetActive(false);
                textoNotificacion.text =("RESPUESTA CORRECTA");
            }
            else
            {
                Debug.Log("Respuesta Incorrecta");
                respuestaCorrecta.SetActive(false);
                respuestaIncorrecta.SetActive(true);
                textoNotificacion.text = ("RESPUESTA INCORRECTA");
            }

            panelNotificaciones.SetActive(true);
        }
    
}
  public void BotonReintentarOnClick()
    {
        panelNotificaciones.SetActive(false);
        respuestaIncorrecta.SetActive(false);
    InputFieldsuma.text = "";
    DeactivateAll();
    Activate();
    }

public void BotonReiniciarOnClick()
    {
        panelNotificaciones.SetActive(false);
        respuestaCorrecta.SetActive(false );
        InputFieldsuma.text = "";
        DeactivateAll();
        Activate();

    }
public void BotonsalirOnClick()
{
        SceneManager.LoadScene("UI");
}
    }
  
