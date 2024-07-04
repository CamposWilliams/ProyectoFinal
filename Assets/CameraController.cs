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
        //Inicialmente, establecer la rotación de la cámara para que mire hacia adelante
        transform.rotation = Quaternion.LookRotation(player.forward);
    }

    void Update()
    {
        //Rotar la cámara horizontalmente basada en la posición del jugador
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        transform.RotateAround(player.position, Vector3.up, mouseX);

        //Limitar la rotación vertical de la cámara
        verticalRotation -= Input.GetAxis("Mouse Y") * rotationSpeed;
        verticalRotation = Mathf.Clamp(verticalRotation, -45f, 45f); 

        transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }
}