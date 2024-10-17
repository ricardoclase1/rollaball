using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Contador : MonoBehaviour
{
    public Text ContadorTexto;
    public int Minutos;
    public float Segundos;
    public Color ColorAviso;
    public float SegundosLimite;
    public bool TiempoAgotado;

    private void Start()
    {
        ActualizarContador();
    }

    private void Update()
    {
        if (TiempoAgotado)
        {
            // Mensaje que debería mostrarse cuando el tiempo se agota
            ContadorTexto.text = "Se acabó el tiempo de juego, inténtalo de nuevo...";
            Debug.Log("El tiempo se ha agotado."); // Verificar que se ejecute esta parte
            return; // Evita que siga restando el tiempo
        }

        Segundos -= Time.deltaTime;

        if (Segundos <= 0)
        {
            if (Minutos == 0) // Cuando Minutos y Segundos llegan a 0
            {
                Accion();  // Ejecuta la acción de tiempo agotado
            }
            else
            {
                Segundos = 60; // Resetea los segundos si quedan minutos
                Minutos -= 1;  
            }
        }

        ActualizarContador();

        // Cambia el color si está cerca de agotarse el tiempo
        if (Segundos < SegundosLimite && Minutos < 1)
        {
            ContadorTexto.color = ColorAviso;
        }
    }

    public void ActualizarContador()
    {
        if (Segundos < 9.9f)
        {
            if (Minutos < 1)
            {
                ContadorTexto.text = Minutos.ToString() + ":" + Segundos.ToString("0.0");
            }
            else
            {
                ContadorTexto.text = Minutos.ToString() + ":0" + Segundos.ToString("f0");
            }
        }
        else
        {
            ContadorTexto.text = Minutos.ToString() + ":" + Segundos.ToString("f0");
        }
    }

    public void Accion()
    {
        TiempoAgotado = true; // Marca que el tiempo se ha agotado
        Debug.Log("Tiempo Agotado, se debería mostrar el mensaje."); // Verifica si se ejecuta esta función
    }
}
