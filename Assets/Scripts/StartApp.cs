using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartApp : MonoBehaviour
{
    /*
     * Funcion encargada de llevarnos a la escena correspondiente a la visualizacion de PC's y componentes en superficies.
     */
    public void StartAR()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /*
     * Funcion que se encarga de llevarnos a la escena correspondiente a la visualizacion de componentes
     */
    public void StartVisualizer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    /*
     * Funcion que se encarga de regresarnos a la pantalla principal de nuestra aplicacion
    */
    public void Home()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - SceneManager.GetActiveScene().buildIndex);
    }

}
