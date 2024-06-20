using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

// Clase que controla el comportamiento del enemigo en el juego
public class Enemigo : MonoBehaviour
{
    // Referencia al GameObject del personaje que el enemigo sigue
    public GameObject Personaje;
    // Prefab de la bala que el enemigo dispara
    public GameObject BulletPrefab;
    // Tiempo del último disparo
    private float LastShoot;
    // Cantidad de vidas del enemigo
    public int vidas = 2;

    public float Speed;

    void Update()
    {
        // Si no hay un personaje asignado, no hace nada
        if (Personaje == null) return;

        // Calcula la dirección hacia el personaje
        Vector3 direccion = Personaje.transform.position - transform.position;

         // Verifica si el personaje está a la derecha o a la izquierda del enemigo
        if (direccion.x >= 0.0f)
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        // Calcula la distancia horizontal al personaje
        float distance = Mathf.Abs(Personaje.transform.position.x - transform.position.x);

        if (distance < 1.0f && Time.time > LastShoot + 0.25f)
        {
            // Dispara
           // Shoot();

            // Actualiza el tiempo del último disparo
            LastShoot = Time.time;
        }
    }

     // Método que controla el disparo del enemigo
     /*
    private void Shoot()
    {
        Debug.Log("Shoot");

        // Determina la dirección del disparo dependiendo de la orientación del enemigo
        Vector3 direction = (transform.localScale.x == 1.0f) ? Vector3.right : Vector3.left;
        
        // Instancia una bala en la posición adecuada y con la orientación correcta
        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);

        // Establece la dirección de la bala
        bullet.GetComponent<BalaPoder>().SetDirection(direction);
    }}*/

    // Método llamado cuando el enemigo recibe un golpe
    public void Hit()
    {
        // Reduce la cantidad de vidas del enemigo
        vidas -= 1; // Reduce la cantidad de vidas

        Debug.Log("Vidas restantes del enemigo: " + vidas);

        // Si las vidas llegan a cero, destruye el enemigo
        if (vidas <= 0) 
        {
            Destroy(gameObject); 
        }
    }
}