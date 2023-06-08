using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AppControl : MonoBehaviour
{

    [SerializeField] private MultiTarget[] Changers;

    [SerializeField] private TextMeshProUGUI Seccion;
    [SerializeField] private TextMeshProUGUI componentName;
    [SerializeField] private TextMeshProUGUI componentDesc;
    private int actualSection;

    // Start is called before the first frame update


    /*
     * Funcion encargada de cambiar el modelo dentro del ImageTarget actual
     * @param index decide si vamos hacia el anterior modelo o el siguiente. 
     */
    public void changeModel(int index)
    {
        Changers[actualSection].ChangeARModel(index);
        //Se llama a la funcion encargada de actualizar los campos relacionados con el componente actual.
        updateComponentName(Changers[actualSection].returnActualComponent());
    }

    /*
    * Funcion encargada de actualizar el contenido de la UI de forma dínamica
    * @param Nombre Se trata de un ScriptableObject de tipo Seccion. 
    */
    public void UpdateUI(Seccion Nombre)
    {
        Seccion.text = Nombre.seccionName;
        actualSection = Nombre.seccionIndex;
        updateComponentName(Changers[actualSection].returnActualComponent());
    }

    /*
     * Funcion que actualiza el canvas con el nombre del componente actual desplegado
     * @param component: ScriptableObjetc de tipo Component
     */
    public void updateComponentName(Component component)
    {
        componentName.text = component.ComponentName;
        componentDesc.text = component.ComponentDesc;

    }
}
