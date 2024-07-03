using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class controllerRegistrar : MonoBehaviour
{
    public void SendRequest(string username, Action<model_Usuario> OnCallback)
    {
        StartCoroutine(Register(username, OnCallback));
    }

    IEnumerator Register(string username, Action<model_Usuario> OnCallback)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/ProyectoFinal/insert_Usuario.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.ConnectionError &&
                www.result != UnityWebRequest.Result.ProtocolError)
            {
                string response = www.downloadHandler.text;
                Debug.Log("Respuesta del servidor: " + response);

                OnCallback(JsonUtility.FromJson<model_Usuario>(www.downloadHandler.text));
            }
            else
            {
                Debug.Log("Error en la conexión con el servidor");
            }
        }
    }
}