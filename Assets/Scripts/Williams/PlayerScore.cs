using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public void AddPoints(int points)
    {
        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.AddPoints(points);
        }
    }
}