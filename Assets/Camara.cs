using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform target; // Referencia al jugador u objeto que quieres seguir
    public float height = 10f; // Altura a la que se ubicará la cámara
    public float distance = 10f; // Distancia desde la cámara al jugador
    
    void Update()
    {
        if (target == null)
            return;

        // Actualiza la posición de la cámara respecto al jugador
        Vector3 newPosition = target.position - Vector3.forward * distance;
        newPosition.y = height; // Ajusta la altura de la cámara

        transform.position = newPosition;

        // Mantiene la rotación hacia abajo (vista cenital)
        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
    }
}
