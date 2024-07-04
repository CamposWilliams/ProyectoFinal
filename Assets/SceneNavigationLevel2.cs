using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneNavigationLevel2 : MonoBehaviour
{
    //Variable pública para el nombre de la escena
    public string nombreEscena; 

    void Update()
    {
        //Verificación si se presionó la tecla Tab
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //Cargar la escena especificada
            SceneManager.LoadScene(nombreEscena);
        }
    }
}