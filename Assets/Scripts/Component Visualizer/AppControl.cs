using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AppControl : MonoBehaviour
{
    [SerializeField] private GameObject GeneralUI;
    [SerializeField] private MultiTarget[] Changers;
        
    [SerializeField] private TextMeshProUGUI Seccion;
    private int actualSection;
    // Start is called before the first frame update
    void Start()
    {

        GeneralUI.SetActive(true);
    }

    public void changeModel(int index)
    {
        Changers[actualSection].ChangeARModel(index);
    }

    public void UpdateUI(Seccion Nombre)
    {
        Seccion.text = Nombre.seccionName;
        actualSection = Nombre.seccionIndex;
    }
}
