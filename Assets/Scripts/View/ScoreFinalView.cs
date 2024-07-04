using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreFinalView : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private InsertFinalScoreController controller;

    private void Awake()
    {
        controller = GetComponent<InsertFinalScoreController>();
    }

    void Start()
    {
        DisplayFinalScores();
    }

    void DisplayFinalScores()
    {
        int userId = 1; //referencial
        int levelId = 1; //referencial
        int enemiesKilled = 10; //referencial
        int score = enemiesKilled * 100; //referencial

        controller.SendRequest(userId, levelId, enemiesKilled, score, OnResult);
    }

    private void OnResult(InsertFinalScoreDataModel data)
    {
        if (data != null)
        {
            scoreText.text = "Mensaje: " + data.message;
        }
        else
        {
            scoreText.text = "Error al insertar el puntaje";
        }
    }
}