using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneMenuController : MonoBehaviour
{
    //Referencia al botón inicié
    public Button inicie;

    void Start()
    {
        //Asignar el evento de clic al botón
        inicie.onClick.AddListener(CargarNivel1);
    }

    public void CargarNivel1()
    {
        SceneManager.LoadScene("Nivel1");
    }
}