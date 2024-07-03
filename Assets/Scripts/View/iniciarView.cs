using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class iniciarView : MonoBehaviour
{
    [SerializeField] private TMP_InputField usernameInputField;
    [SerializeField] private Button loginButton;
    [SerializeField] private TextMeshProUGUI messageText;
    private controller_Usuario controller;
    private void Awake()
    {
        loginButton.onClick.AddListener(ClickLogin);
        controller = GetComponent<controller_Usuario>();
    }

    private void ClickLogin()
    {
        controller.SendRequest(usernameInputField.text, OnResult);
    }

    private void OnResult(model_Usuario modelUsuario)
    {
        if (modelUsuario != null)
        {
            if (modelUsuario.data != null)
            {
                messageText.text = $"{modelUsuario.message}:\n{modelUsuario.data.user.username}";
                StaticData.user_id = modelUsuario.data.user.user_id;
                StaticData.username = modelUsuario.data.user.username;
                //SceneManager.LoadScene("LevelSelectionScene");
            }
            else
            {
                messageText.text = $"{modelUsuario.message}";
            }
        }
        else
        {
            messageText.text = "Error desconocido";
        }
    }
}
