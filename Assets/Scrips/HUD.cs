using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Clase que controla la interfaz de usuario (HUD) del juego
public class HUD : MonoBehaviour
{
	// Referencia al componente TextMeshProUGUI que muestra los puntos
    public TextMeshProUGUI puntos;
	// Array de GameObjects que representan las vidas del jugador en la interfaz
	public GameObject[] vidas;
    
	void Update () {
		// Actualiza el texto del componente "puntos" con el total de puntos actuales del GameManager
		puntos.text = GameManager.Instance.PuntosTotales.ToString();
	}

	// Método para actualizar los puntos mostrados en la interfaz
	public void ActualizarPuntos(int puntosTotales)
	{
		// Actualiza el texto del componente "puntos" con el valor pasado como parámetro
		puntos.text = puntosTotales.ToString();
	} 

	// Método para desactivar una vida en la interfaz
	public void DesactivarVida(int indice) {
		// Desactiva el GameObject en el índice especificado del array "vidas"
		vidas[indice].SetActive(false);
	}

	// Método para activar una vida en la interfaz
	public void ActivarVida(int indice) {
		// Activa el GameObject en el índice especificado del array "vidas"
		vidas[indice].SetActive(true);
	}
} 