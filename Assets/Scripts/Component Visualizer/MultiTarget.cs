using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiTarget : MonoBehaviour
{
    [SerializeField] private GameObject startModel;
    [SerializeField] private Component[] components;
    private int modelsCount;
    private int indexCurrentModel;

    // Start is called before the first frame update
    void Start()
    {
        //Se cuenta el numero de modelos dentro de un imageTarget
        modelsCount = transform.childCount;
        indexCurrentModel = startModel.transform.GetSiblingIndex();
    }


    /*
     * Funcion encargada de realizar el cambio de modelos dentro de un imageTarget
     * @param index decide si vamos hacia el anterior modelo o el siguiente. 
     */
    public void ChangeARModel(int index)
    {
        //Obtenemos el modelo actual desplegado y lo ocultamos
        transform.GetChild(indexCurrentModel).gameObject.SetActive(false);

        int newIndex = indexCurrentModel + index;

        if(newIndex < 0)
        {
            newIndex = modelsCount - 1;
        }
        else if(newIndex > modelsCount -1)
        {
            newIndex = 0;
        }

        //Obtenemos el nuevo modelo y lo activamos
        GameObject newModel = transform.GetChild(newIndex).gameObject;
        newModel.SetActive(true);


        //Actualizamos el indice actual de nuestro sistema
        indexCurrentModel = newModel.transform.GetSiblingIndex();
    }

    /*
     * Función encargada de brindar el ScriptableObject activo en el imageTarget
     * @return Un ScriptableObject de tipo componente
     */
    public Component returnActualComponent()
    {
        return components[indexCurrentModel];
    }
}
