using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform targetObj;
    public float moveSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        if (targetObj == null)
            return;

        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetObj.position, moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Movement>().TakeDamage(1);
        }
    }
}
