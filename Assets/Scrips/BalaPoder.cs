using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que controla el comportamiento de la bala
public class BalaPoder : MonoBehaviour
{
    // Velocidad de la bala
    public float Speed;
    // Componente Rigidbody2D para manejar la física de la bala
    private Rigidbody2D Rigidbody2D;
    // Dirección en la que la bala se moverá
    private Vector2 Direction;
    // Clip de sonido que se reproducirá cuando la bala se dispare
    public AudioClip sonidoFX;
    // Animator para la animación de destrucción de la bala
    private Animator animator;

    // Método llamado al inicio de la vida del objeto
    void Start()
    {
        // Obtiene el componente Rigidbody2D del objeto
        Rigidbody2D = GetComponent<Rigidbody2D>();
        // Reproduce el sonido del disparo usando el componente AudioSource de la cámara principal
        Camera.main.GetComponent<AudioSource>().PlayOneShot(sonidoFX);
        // Obtiene el componente Animator del objeto
        animator = GetComponent<Animator>();
    }

    // Método llamado a intervalos regulares para actualizar la física del objeto
    private void FixedUpdate()
    {
        // Establece la velocidad del Rigidbody2D en la dirección especificada con la velocidad asignada
        Rigidbody2D.velocity = Direction * Speed;
    }

    // Método para establecer la dirección de la bala
    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }

    // Método para destruir la bala
    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    // Método llamado cuando la bala colisiona con otro objeto
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Intenta obtener el componente Jhon del objeto con el que colisiona
        Jhon jhon = collision.GetComponent<Jhon>();

        // Intenta obtener el componente Enemigo del objeto con el que colisiona
        Enemigo grunt = collision.GetComponent<Enemigo>();

        // Si colisiona con el objeto Jhon, aplica daño a Jhon
        if (jhon != null)
        {
            Debug.Log("Daño aplicado a Jhon");
            jhon.Hit();
        }

        if (grunt != null)
        {
            Debug.Log("Daño aplicado a enemigo");
            grunt.Hit();
        }
        
        // Destruye la bala después de la colisión
        DestroyBullet();
    }
}