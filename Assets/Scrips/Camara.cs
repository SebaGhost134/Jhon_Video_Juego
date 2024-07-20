using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que controla el comportamiento de la cámara
public class Camara : MonoBehaviour
{
    public GameObject Jhon;
    void Start()
    {
        
    }

    // Update is called once per frame
   void Update()
    {
        if (Jhon != null)
        {
            // Obtiene la posición actual de la cámara
            Vector3 position = transform.position;
            position.x = Jhon.transform.position.x;
            position.y = Jhon.transform.position.y;
            // Establece la nueva posición de la cámara
            transform.position = position;
        }
    }
}
