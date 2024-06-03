using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que controla el comportamiento de las monedas (hachas) en el juego
public class Coin : MonoBehaviour
{
    // Valor de la moneda
    public int valor = 1;
    // Referencia al GameManager para actualizar los puntos
    public GameManager game;

    // Método que se llama cuando otro collider entra en el trigger de este GameObject
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el collider que entra en el trigger tiene la etiqueta "Player"
        if(collision.CompareTag("Player"))
        {
            // Llama al método SumarPuntos del GameManager y le pasa el valor de la moneda
            game.SumarPuntos(valor);
            // Destruye este GameObject (la moneda) del juego
            Destroy(this.gameObject);
        }
        
    }
}