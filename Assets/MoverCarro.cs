using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoverCarro : MonoBehaviour
{
    public float maxForwardSpeed = 10f; // Velocidad máxima de movimiento hacia adelante
    public float maxBackwardSpeed = 5f; // Velocidad máxima de movimiento hacia atrás
    public float acceleration = 5f; // Aceleración del carro
    public float deceleration = 10f; // Deceleración del carro
    public float rotationSpeed = 100f; // Velocidad de rotación del carro
    private float currentSpeed = 0f; // Velocidad actual del carro
    private Rigidbody rb;
    public int lapsCompleted = 0; // Contador de vueltas completadas
    public Text lapsText; // Referencia al objeto de texto en el canvas
    
    public ParticleSystem particulas;
 
    void Start (){
        UpdateLapsText();
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        // Obtener la entrada del teclado
        float verticalInput = Input.GetAxis("Vertical"); // Eje vertical para adelante/atrás (W/S)
        float horizontalInput = Input.GetAxis("Horizontal"); // Eje horizontal para girar (A/D)

        // Calcular la velocidad actual basada en la entrada
        if (verticalInput > 0f)
        {
            // Acelerar hacia adelante
            currentSpeed = Mathf.MoveTowards(currentSpeed, maxForwardSpeed, acceleration * Time.deltaTime);
            particulas.Play();
        }
        else if (verticalInput < 0f)
        {
            // Acelerar hacia atrás
            currentSpeed = Mathf.MoveTowards(currentSpeed, -maxBackwardSpeed, acceleration * Time.deltaTime);
        }
        else
        {
            // Desacelerar (frenado suave)
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, deceleration * Time.deltaTime);
        }

        // Calcular el movimiento y la rotación basados en la velocidad actual
        float translation = currentSpeed * Time.deltaTime;
        float rotation = horizontalInput * rotationSpeed * Time.deltaTime;

        // Mover el carro hacia adelante/atrás
        transform.Translate(0, 0, translation);
        
        // Girar el carro
        transform.Rotate(0, rotation, 0);

    }
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el jugador ha atravesado el Trigger
        if (other.CompareTag("Finish"))
        {
            lapsCompleted++; // Incrementa el contador de vueltas
            UpdateLapsText();
        }
        if (other.CompareTag("Sand"))
        {
            // Reduce la velocidad a la mitad
            maxForwardSpeed=5f;
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
    void OnTriggerExit(Collider other)
    {
        // Restaura la velocidad normal cuando el carro deja de estar en contacto con el objeto "Sand"
        if (other.CompareTag("Sand"))
        {
            maxForwardSpeed = 10f; // Puedes ajustar esto según cómo quieras restaurar la velocidad
        }
    }
    

}
