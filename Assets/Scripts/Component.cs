using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Component : ScriptableObject
{
    public string ComponentName;
    public Sprite ComponentImage;
    public string ComponentDesc;
    public GameObject ComponentModel;

    public void printComponentData()
    {
        Debug.Log(ComponentName);
        Debug.Log(ComponentDesc);
    }

}

