using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vueltas : MonoBehaviour
{
    public int lapsCompleted = 0; // Contador de vueltas completadas
    public Text lapsText; // Referencia al objeto de texto en el canvas

    private void Start()
    {
        UpdateLapsText();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el jugador ha atravesado el Trigger
        if (other.CompareTag("Finish"))
        {
            lapsCompleted++; // Incrementa el contador de vueltas
            UpdateLapsText();
        }
    }

    void UpdateLapsText()
    {
        // Actualiza el texto en el objeto de texto del canvas
        if (lapsText != null)
        {
            lapsText.text = "Vueltas: " + lapsCompleted;
        }
    }
}
