using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * ScriptableObject encargado de enviar informacion al canva component, cuenta con un nombre de sección y con un índice.
 * 
 * CreateAssetMenu se usa para traer este ScriptableObject al menú de creacion de elementos dentro de Unity
 */
[CreateAssetMenu]
public class Seccion : ScriptableObject
{
    public string seccionName;
    public int seccionIndex;
}
