using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AppManager : MonoBehaviour
{
    //Creacion de eventos para cada menú dentro de la escena
    public event Action OnMainMenu;
    public event Action OnItemsMenu;
    public event Action OnARPosition;

    //Instanciado de AppManager dentro de AppManager con el fin de poder ser usado en otros scripts
    public static AppManager instance;

    /*
     * Funcion que comprueba si ya hay una instancia del AppManager y destruye este objeto si es así
     */
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Mandamos a llamar a la funcion que activa el menú principal 
        MainMenu();
    }

    /*
     * Funcion que activa la vista del menú principal de la escena
     */
    public void MainMenu()
    {
        //Invoca al evento y a todas las funciones suscritas al mismo
        OnMainMenu?.Invoke();
        Debug.Log("Main Menu Activated");
    }

    /*
     * Funcion que activa la vista de seleccion de componentes
     */
    public void ItemsMenu()
    {
        //Invoca al evento y a todas las funciones suscritas al mismo
        OnItemsMenu?.Invoke();
        Debug.Log("Items Menu Activated");
    }

    /*
     * Funcion que activa la vista de posicionamiento de modelos en superficies
     */
    public void ARPosition()
    {
        //Invoca al evento y a todas las funciones suscritas al mismo
        OnARPosition?.Invoke();
        Debug.Log("AR Position Activated");
    }
}
