using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionModelos : MonoBehaviour
{
    //public GameObject Object;
    public float rotateSpeed = 50f;
    public bool rotateStatus;
    // Start is called before the first frame update
    void Start()
    {
        rotateStatus = true;   
    }

    // Update is called once per frame
    void Update()
    {
        if (rotateStatus)
        {
            transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
        }else
            transform.Rotate(Vector3.up, rotateSpeed * 0);
    }

    public void ChangeRot()
    {
        rotateStatus = !rotateStatus;
    }
}
