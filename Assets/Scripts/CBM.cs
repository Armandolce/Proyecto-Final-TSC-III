using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CBM : MonoBehaviour
{
    public string ComponentName;
    public string ComponentDesc;
    public Sprite ComponentImage;
    public GameObject ComponentModel;
    private ARInteractionManager interactionManager;

    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = ComponentName;
        transform.GetChild(1).GetComponent<RawImage>().texture = ComponentImage.texture;
        transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = ComponentDesc;

        var button = GetComponent<Button>();
        button.onClick.AddListener(AppManager.instance.ARPosition);
        button.onClick.AddListener(Create3DModel);

        interactionManager = FindObjectOfType<ARInteractionManager>();
    }

    private void Create3DModel()
    {
       interactionManager.Item3DModel = Instantiate(ComponentModel);
    }

}
