using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEtapa : MonoBehaviour
{
// Referencia al GameObject que contiene la imagen de final de etapa
public GameObject imagenFinal;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Método llamado cuando otro collider entra en el trigger de este objeto
    private void OnTriggerEnter2D(Collider2D collision){
        // Imprime un mensaje en la consola para indicar que se ha alcanzado el final de la etapa
        Debug.Log("Final");

        // Activa el GameObject que contiene la imagen de final de etapa
        imagenFinal.gameObject.SetActive(true);

        // Intenta obtener el componente Jhon del objeto con el que colisiona
        Jhon Personaje = collision.GetComponent<Jhon>();
        
        // Si el componente Jhon existe en el objeto colisionado, llama al método destruirPersonaje
        Personaje.destruirPersonaje();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
