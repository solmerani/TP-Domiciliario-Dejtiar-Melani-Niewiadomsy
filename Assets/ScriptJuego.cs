using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptJuego : MonoBehaviour
{
    public ArrayProductos productosScript1; // Script para gestionar los productos del primer slot
    public ArrayProductos productosScript2; // Script para gestionar los productos del segundo slot
    public Text textoSuma;
    public InputField inputResultado;
    public GameObject panelNotificaciones;
    public Text MostrarNotificacion;
    public Button botonJugarOtraVez;
    public Button botonSalir;

    private int precioProducto1;
    private int precioProducto2;

    void Start()
    {
        IniciarJuego();
    }

    void IniciarJuego()
    {
        // Activar productos aleatorios
        productosScript1.ActivarObjetoAleatorio();
        productosScript2.ActivarObjetoAleatorio();

        precioProducto1 = productosScript1.objetos[productosScript1.objetosIndex].GetComponent<objetos>().precio;
        precioProducto2 = productosScript2.objetos[productosScript2.objetosIndex].GetComponent<objetos>().precio;

        // Configurar la interfaz de usuario
        inputResultado.text = "";
        inputResultado.placeholder.GetComponent<Text>().text = "?";
        panelNotificaciones.SetActive(false);
    }

    public void Responder()
    {
        if (string.IsNullOrEmpty(inputResultado.text))
        {
            MostrarNotificacion.text =("ingresar un resultado");
            return;
        }

        int resultado;
        if (int.TryParse(inputResultado.text, out resultado))
        {
            if (resultado == precioProducto1 + precioProducto2)
            {
                MostrarNotificacion.text = ("¡Correcto!");
                botonJugarOtraVez.GetComponentInChildren<Text>().text = "Reiniciar el desafío";
            }
            else
            {
                MostrarNotificacion.text = ("Incorrecto, inténtalo de nuevo");
                botonJugarOtraVez.GetComponentInChildren<Text>().text = "Volver a intentarlo";
            }
        }
        else
        {
            MostrarNotificacion.text = ("Debes ingresar un número entero");
        }
    }
}
