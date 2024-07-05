using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform targetObj;
    public float detectionRadius = 10f; 
    public float moveSpeed = 5f; 
    private bool isPlayerInRange = false;

    // Update is called once per frame
    void Update()
{
    if (targetObj == null)
        return; 

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
