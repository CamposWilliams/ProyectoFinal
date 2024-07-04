using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; 
    public float rotationSpeed = 3f; 
    private float verticalRotation = 0f;

    void Start()
    {
        //Inicialmente, establecer la rotaci�n de la c�mara para que mire hacia adelante
        transform.rotation = Quaternion.LookRotation(player.forward);
    }

    void Update()
    {
        //Rotar la c�mara horizontalmente basada en la posici�n del jugador
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        transform.RotateAround(player.position, Vector3.up, mouseX);

        //Limitar la rotaci�n vertical de la c�mara
        verticalRotation -= Input.GetAxis("Mouse Y") * rotationSpeed;
        verticalRotation = Mathf.Clamp(verticalRotation, -45f, 45f); 

        transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }
}