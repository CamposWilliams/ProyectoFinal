using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 10f;
    public Vector3 direction;
    public int damage = 1;
    public float lifeTime = 5f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject); 
            GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.EnemyDefeated();
            }
            PlayerScore playerScore = GameObject.FindObjectOfType<PlayerScore>();
            if (playerScore != null)
            {
                playerScore.AddPoints(1);
            }
        }
        Destroy(gameObject); 
    }
}