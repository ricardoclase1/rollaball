using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject jugador;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - jugador.transform.position;
    }

   void LateUpdate () {
//Actualizo la posición de la cámara
transform.position = jugador.transform.position + offset;
}
}