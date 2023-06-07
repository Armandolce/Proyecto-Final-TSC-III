using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * ScriptableObject encargado de enviar informacion al canva component, cuenta con un nombre de secci�n y con un �ndice.
 * 
 * CreateAssetMenu se usa para traer este ScriptableObject al men� de creacion de elementos dentro de Unity
 */
[CreateAssetMenu]
public class Seccion : ScriptableObject
{
    public string seccionName;
    public int seccionIndex;
}
