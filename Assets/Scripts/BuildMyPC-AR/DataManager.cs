using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    //Lista de ScriptableObjects del tipo Component que se encuentran dentro de nuestra aplicacion.
    [SerializeField] private List<Component> Components = new List<Component>();
    
    [SerializeField] private GameObject buttonContainer;
    [SerializeField] private CBM ComponentButtonManager;
    
    // Start is called before the first frame update. Se agrega la funcion CreateButtons al AppManager
    void Start()
    {
        AppManager.instance.OnItemsMenu += CreateButtons;
    }

    /*
     * Funcion que se encarga de enviar dinamicamente la cantidad de botones conforme al número de componentes agregados a nuestra lista de componentes
     */
    private void CreateButtons()
    {
        //Ciclo for encargado de crear los botones y asignarles la informacion de cada componente.
        foreach( var comp in Components)
        {
            CBM componentButton;
            componentButton = Instantiate(ComponentButtonManager, buttonContainer.transform);
            componentButton.ComponentName = comp.ComponentName;
            componentButton.ComponentDesc = comp.ComponentDesc;
            componentButton.ComponentImage = comp.ComponentImage;
            componentButton.ComponentModel = comp.ComponentModel;
            componentButton.name = comp.ComponentName;
        }

        //Se elimina la funcion del evento.
        AppManager.instance.OnItemsMenu -= CreateButtons; 
    }
}
