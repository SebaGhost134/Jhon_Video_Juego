using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

// Clase que gestiona la lógica central del juego
public class GameManager : MonoBehaviour
{
// Instancia única del GameManager para implementar el patrón Singleton
public static GameManager Instance { get; private set; }
    
	// Referencia al HUD para actualizar la interfaz de usuario
	public HUD hud;

	// Propiedad para obtener el total de puntos acumulados
    public int PuntosTotales {get; private set;}

	// Número de vidas del jugador
	private int vidas = 3;

	// Método que se llama al iniciar el script
    private void Awake()
    {
		// Verifica si no hay una instancia existente del GameManager
        if (Instance == null)
        {
			// Asigna esta instancia como la única instancia del GameManager
            Instance = this;
        }
        else
        {
			// Si ya existe una instancia, muestra un mensaje de advertencia en la consola
            Debug.Log("Cuidado! Mas de un GameManager en escena.");
        }
    }

	// Método para sumar puntos al total y actualizar el HUD
    public void SumarPuntos(int puntosASumar)
    {
		// Suma los puntos al total
        PuntosTotales += puntosASumar;
		// Actualiza el HUD con el nuevo total de puntos
		hud.ActualizarPuntos(PuntosTotales);
    }

	// Método para disminuir una vida al jugador
	public void PerderVida() {
		// Disminuye el número de vidas
		vidas -= 1;

		// Si las vidas llegan a cero
		if(vidas == 0)
		{
			// Reinicia el nivel cargando la escena con índice 0
			SceneManager.LoadScene(3);
		}

		// Actualiza el HUD para desactivar una vida
		hud.DesactivarVida(vidas);
	}

	// Método para recuperar una vida del jugador
	public bool RecuperarVida() {
		// Verifica si las vidas ya están al máximo (3 vidas)
		if (vidas == 3)
		{
			return false;
		}

		// Activa una vida en el HUD
		hud.ActivarVida(vidas);
		// Aumenta el número de vidas
		vidas += 1;
		return true;
	}
}