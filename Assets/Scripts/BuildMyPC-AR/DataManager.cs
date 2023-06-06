using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] private List<Component> Components = new List<Component>();
    [SerializeField] private GameObject buttonContainer;
    [SerializeField] private CBM ComponentButtonManager;
    // Start is called before the first frame update
    void Start()
    {
        AppManager.instance.OnItemsMenu += CreateButtons;
    }

    private void CreateButtons()
    {
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

        AppManager.instance.OnItemsMenu -= CreateButtons; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
