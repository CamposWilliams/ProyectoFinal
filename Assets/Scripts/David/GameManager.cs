using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int enemyCount;
    public string nextLevelName; // El nombre de la siguiente escena

    void Start()
    {
        // Contar todos los enemigos al inicio
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    public void EnemyDefeated()
    {
        enemyCount--;
        if (enemyCount <= 0)
        {
            LoadNextLevel();
        }
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene("Nivel2");
    }
}
