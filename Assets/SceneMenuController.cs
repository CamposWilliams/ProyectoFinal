using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneMenuController : MonoBehaviour
{
    //Referencia al bot�n inici�
    public Button inicie;

    void Start()
    {
        //Asignar el evento de clic al bot�n
        inicie.onClick.AddListener(CargarNivel1);
    }

    public void CargarNivel1()
    {
        SceneManager.LoadScene("Nivel1");
    }
}