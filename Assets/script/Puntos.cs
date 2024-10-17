using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntos : MonoBehaviour
{
    public Vector3 rotacion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(rotacion * Time.deltaTime);
    }

    void OnTriggerEnter(Collider colision)
    {
        if(colision.CompareTag("Jugador"))
        {
            Destroy(this.gameObject);
        }       
    }
}


