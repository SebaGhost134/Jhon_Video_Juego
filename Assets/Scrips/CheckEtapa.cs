using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEtapa : MonoBehaviour
{
    // Referencia al GameObject que contiene la imagen de final de etapa
    public GameObject imagenFinal;


    // Start se llama antes de la primera actualización del frame
    void Start()
    {
        // Asegurarse de que imagenFinal esté asignado
        if (imagenFinal == null)
        {
            Debug.LogError("¡imagenFinal no está asignado en el inspector!");
        }
    }

    // Método llamado cuando otro collider entra en el trigger de este objeto

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))  // Asumiendo que solo el jugador debe activar esto
        {
            Debug.Log("Final");

            if (imagenFinal != null)
            {
                imagenFinal.gameObject.SetActive(true);
            }
            else
            {
                Debug.LogError("¡imagenFinal es null! No se puede activar.");
            }

            Jhon Personaje = collision.GetComponent<Jhon>();

            if (Personaje != null)
            {
                Personaje.destruirPersonaje();
            }
            else
            {
                Debug.LogError("¡El objeto colisionado no tiene un componente Jhon!");
            }
        
        }
        
    }

    // Update se llama una vez por frame
    void Update()
    {
        
    }
}