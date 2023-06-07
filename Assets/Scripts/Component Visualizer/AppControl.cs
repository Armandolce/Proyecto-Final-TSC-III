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

    public void changeModel(int index)
    {
        Changers[actualSection].ChangeARModel(index);
        updateComponentName(Changers[actualSection].returnActualComponent());
    }

    public void UpdateUI(Seccion Nombre)
    {
        Seccion.text = Nombre.seccionName;
        actualSection = Nombre.seccionIndex;
        updateComponentName(Changers[actualSection].returnActualComponent());
    }
    public void updateComponentName(Component component)
    {
        componentName.text = component.ComponentName;
        componentDesc.text = component.ComponentDesc;

    }
}
