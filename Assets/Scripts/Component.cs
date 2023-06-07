using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * ScriptableObject encargado de enviar informacion al canva menuItems, cuenta con el nombre del componente
 * una imagen descriptiva, una descripcion corta del elemento y un modelo 3D a desplegar en una superficie.
 * 
 * CreateAssetMenu se usa para traer este ScriptableObject al menú de creacion de elementos dentro de Unity
 */
[CreateAssetMenu]
public class Component : ScriptableObject
{
    public string ComponentName;
    public Sprite ComponentImage;
    public string ComponentDesc;
    public GameObject ComponentModel;

}

