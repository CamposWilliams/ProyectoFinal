using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform targetObj;
    public float detectionRadius = 10f; // Radio de detección
    public float moveSpeed = 5f; // Velocidad de movimiento
    private bool isPlayerInRange = false;

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, targetObj.position);

        if (distanceToPlayer <= detectionRadius)
        {
            isPlayerInRange = true;
            MoveTowardsPlayer();
        }
        else
        {
            isPlayerInRange = false;
        }
    }

    void MoveTowardsPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetObj.position, moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && isPlayerInRange)
        {
            collision.gameObject.GetComponent<Movement>().TakeDamage(1);
        }
    }
}
