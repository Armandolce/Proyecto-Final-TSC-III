using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


/*
 * Clase encargada de enviar la informacion de cada componente al canva onItemsMenu en forma de boton
 */
public class CBM : MonoBehaviour
{
    //Atributos correspondientes al ScriptableObject Component
    public string ComponentName;
    public string ComponentDesc;
    public Sprite ComponentImage;
    public GameObject ComponentModel;

    //Encargado de llevar las interacciones en la aplicacion
    private ARInteractionManager interactionManager;

    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = ComponentName;
        transform.GetChild(1).GetComponent<RawImage>().texture = ComponentImage.texture;
        transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = ComponentDesc;

        var button = GetComponent<Button>();
        
        /* Al hacer tap en el boton del componente deseado, comenzaremos el proceso de colocacion del modelo, para ello agregamos Listeners que
        *  llaman al menú correspondiente e instancian el modelo 3D del componente seleccionado
        */
        button.onClick.AddListener(AppManager.instance.ARPosition);
        button.onClick.AddListener(Create3DModel);

        interactionManager = FindObjectOfType<ARInteractionManager>();
    }
    /*
     * Funcion encargada de instanciar el modelo seleccionado con el boton.
     */
    private void Create3DModel()
    {
       interactionManager.Item3DModel = Instantiate(ComponentModel);
    }

}
