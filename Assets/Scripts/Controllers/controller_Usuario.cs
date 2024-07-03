using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class controller_Usuario : MonoBehaviour
{
    public void SendRequest(string username, Action<model_Usuario> OnCallback)
    {
        StartCoroutine(Login(username, OnCallback));
    }

    IEnumerator Login(string username, Action<model_Usuario> OnCallback)
    {
        WWWForm form = new WWWForm();
        form.AddField("nombre", username); 
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/ProyectoFinal/insert_Usuario.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError ||
                www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log("Error");
            }
            else
            {
                OnCallback(JsonUtility.FromJson<model_Usuario>(www.downloadHandler.text));
            }
        }
    }
}