using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class InsertFinalScoreController : MonoBehaviour
{
    public void SendRequest(int user_id, int level_id, int enemies_killed, int score, Action<InsertFinalScoreDataModel> OnCallback)
    {
        StartCoroutine(InsertFinalScore(user_id, level_id, enemies_killed, score, OnCallback));
    }

    IEnumerator InsertFinalScore(int user_id, int level_id, int enemies_killed, int score, Action<InsertFinalScoreDataModel> OnCallback)
    {
        WWWForm form = new WWWForm();
        form.AddField("Usuarios_id", user_id);
        form.AddField("Niveles_id", level_id);
        form.AddField("enemigosAsesinados", enemies_killed);
        form.AddField("puntaje", score);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/ProyectoFinal/insert_Puntaje.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.ConnectionError && www.result != UnityWebRequest.Result.ProtocolError)
            {
                if (www.downloadHandler.text.Length > 0)
                {
                    OnCallback(JsonUtility.FromJson<InsertFinalScoreDataModel>(www.downloadHandler.text));
                }
                else
                {
                    OnCallback(new InsertFinalScoreDataModel { message = "Error al insertar el puntaje" });
                }
            }
            else
            {
                Debug.Log("Error al insertar el puntaje final");
            }
        }
    }
}