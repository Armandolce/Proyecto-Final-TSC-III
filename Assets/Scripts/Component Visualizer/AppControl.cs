using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppControl : MonoBehaviour
{
    [SerializeField] private GameObject[] Canvas; 
    [SerializeField] private GameObject GeneralUI; 
    // Start is called before the first frame update
    void Start()
    {
        foreach (var UI in Canvas)
        {
            UI.SetActive(false);
        }

        GeneralUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
