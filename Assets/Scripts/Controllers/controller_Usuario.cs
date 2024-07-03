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
        form.AddField("username", username);
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


    /*[SerializeField] private model_Usuario modelUsuario;-----
    // Start is called before the first frame update
    void Start()
    {
    }
    public void SendRequest(string username, Action<model_Usuario> OnCallback)
    {

        StartCoroutine(GetUser(username, OnCallback));
    }

    IEnumerator GetUser(string username, Action<model_Usuario> OnCallback)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        using (UnityWebRequest www = UnityWebRequest.Post("http//localhost/ProyectoFinal/insert_Usuario.php", form)) 
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError ||
                www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log("Error");
            }
            else
            {
                modelUsuario = JsonUtility.FromJson<model_Usuario>(www.downloadHandler.text);
                OnCallback(modelUsuario);
            }
        }
    }*/
}
