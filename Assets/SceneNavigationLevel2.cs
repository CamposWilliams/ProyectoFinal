using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneNavigationLevel2 : MonoBehaviour
{
    //Variable p�blica para el nombre de la escena
    public string nombreEscena; 

    void Update()
    {
        //Verificaci�n si se presion� la tecla Tab
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //Cargar la escena especificada
            SceneManager.LoadScene(nombreEscena);
        }
    }
}