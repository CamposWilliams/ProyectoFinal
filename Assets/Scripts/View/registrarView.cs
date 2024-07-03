using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class registrarView : MonoBehaviour
{
    [SerializeField] private TMP_InputField usernameInputField;
    [SerializeField] private Button registerButton;
    [SerializeField] private TextMeshProUGUI messageText;
    private controllerRegistrar controller;
    private void Awake()
    {
        registerButton.onClick.AddListener(ClickRegister);
        controller = GetComponent<controllerRegistrar>();
    }

    private void ClickRegister()
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
