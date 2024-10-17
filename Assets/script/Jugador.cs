using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // Asegúrate de usar TextMeshPro

public class NewBehaviourScript : MonoBehaviour
{
    public float velocidad;
    public Rigidbody fisica;
    private int puntos;
    public int totalMonedas;  // Cantidad total de monedas en la escena
    public TMP_Text textoGanador; // Texto de "Ganaste" en UI (TextMeshPro)
    public TMP_Text countText;    // Texto para contar las monedas

    void Start()
    {
        fisica = GetComponent<Rigidbody>();
        puntos = 0;  // Inicializa el puntaje en 0

        // Desactiva el texto de victoria al inicio
        textoGanador.gameObject.SetActive(false);

        // Cuenta todas las monedas en la escena al inicio
        totalMonedas = GameObject.FindGameObjectsWithTag("Moneda").Length;

        // Inicializa el texto de puntaje
        SetCountText();
    }

    void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        Vector3 movimientos = new Vector3(movimientoHorizontal, 0, movimientoVertical);
        fisica.AddForce(movimientos * velocidad);
    }

    void OnTriggerEnter(Collider colision)
    {
        if (colision.CompareTag("Moneda"))
        {
            colision.gameObject.SetActive(false);  // Desactiva la moneda
            puntos++;  // Aumenta el puntaje

            // Actualiza el texto del puntaje
            SetCountText();

            // Verifica si se recogieron todas las monedas
            if (puntos >= totalMonedas)
            {
                MostrarTextoGanador();
            }
        }    
    }

    void MostrarTextoGanador()
    {
        // Muestra el texto de victoria
        textoGanador.gameObject.SetActive(true);
    }

    // Actualiza el puntaje en la UI
    void SetCountText()
    {
        countText.text = "Count: " + puntos.ToString();

        // Opcional: Muestra el mensaje de victoria si se han recogido todas las monedas
        if (puntos >= totalMonedas)
        {
            textoGanador.gameObject.SetActive(true);
        }
    }
}
