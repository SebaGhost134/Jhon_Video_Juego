using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jhon : MonoBehaviour
{
    // Prefab de la bala que dispara Jhon
    public GameObject BulletPrefab;
    // Fuerza del salto de Jhon
    public float fuerzaSalto;
    // Referencia al componente Animator para manejar animaciones
    private Animator Animator;
    // Variable que almacena el valor de la entrada horizontal
    private float horizontal;
    // Booleano para controlar la dirección en la que mira Jhon
    private bool mirarDerecha=true;
     // Componente Rigidbody2D para manejar la física del movimiento
    private Rigidbody2D movimiento;
    // Booleano para verificar si Jhon puede saltar
    private bool salto;
    // Velocidad de movimiento de Jhon
    public float velocidad;
    // Momento en el tiempo del último disparo
    public float LastShoot;
    // Cantidad de vidas de Jhon
    public int vidas = 5;

    // Start es lo que se inicia en la clase
    void Start()
    {
        // Obtiene y guarda el componente Rigidbody2D del objeto
        movimiento = GetComponent<Rigidbody2D>();

        // Obtiene y guarda el componente Animator del objeto
        Animator = GetComponent<Animator>();
    }

    // Update se ejecuta mientras el freim se actualiza
    void Update()
    {
        // Obtiene la entrada horizontal del usuario 
        horizontal = Input.GetAxisRaw("Horizontal");
        // Actualiza la variable "running" del Animator dependiendo si hay movimiento horizontal
        Animator.SetBool("running", horizontal != 0.0f);

        // Verifica si Jhon está tocando el suelo usando un Raycast
        if(Physics2D.Raycast(transform.position,Vector3.down,1.1f))
        {
            salto = true;
        }
        else
        {
            salto = false;
        }

        // Si se presiona la tecla "W" y Jhon puede saltar, realiza el salto
        if (Input.GetKeyDown(KeyCode.W)&& salto){
            Saltar();
        }

        // Llama al método Flip para manejar la orientación de Jhon
        Flip();
        // Si se mantiene presionada la barra espaciadora y ha pasado suficiente tiempo desde el último disparo
        if (Input.GetKey(KeyCode.Space) && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }
    
    // Método para realizar el salto
    private void Saltar()
    {

        // Ajusta la velocidad vertical del Rigidbody2D para realizar el salto
        movimiento.velocity=new Vector2(movimiento.velocity.x,fuerzaSalto);
    }

    // Método para manejar el disparo de Jhon
    private void Shoot()
    {
        Vector3 direction;
        // Determina la dirección del disparo dependiendo de la orientación del vikingo
        if (transform.localScale.x == 1.0f)
        {
            direction = Vector3.right;
        }
        else
        {
            direction = Vector3.left;
        }
        // Instancia una bala en la posición adecuada y con la orientación correcta
        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BalaPoder>().SetDirection(direction);
    }


    // Método para manejar la orientación de Jhon
    private void Flip()
    {
        // Cambia la dirección en la que mira el vikingo dependiendo de la entrada horizontal
        if(mirarDerecha && horizontal<0f || !mirarDerecha && horizontal >0f){
           Vector3 localScale=transform.localScale;
           mirarDerecha=! mirarDerecha;
           localScale.x*=-1f;
           transform.localScale=localScale; 
        }
    }
    // Método que se llama en intervalos de tiempo fijos para manejar la física
    private void FixedUpdate()
    {
        // Actualiza la velocidad del Rigidbody2D para mover a Jhon horizontalmente
        movimiento.velocity = new Vector2(horizontal*velocidad,movimiento.velocity.y);
    }

    // Método que se llama cuando Jhon recibe un golpe
    public void Hit(){
        // Reduce la cantidad de vidas de Jhon
        vidas = vidas -1;
        // Si las vidas llegan a cero, destruye el objeto
        if (vidas == 0) Destroy(gameObject);
    }
    
    // Método para destruir el objeto Jhon
     public void destruirPersonaje(){
        Destroy(gameObject);
     }
}
    
