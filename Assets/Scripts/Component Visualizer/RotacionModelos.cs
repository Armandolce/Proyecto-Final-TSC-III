using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionModelos : MonoBehaviour
{
    public float rotateSpeed = 50f;
    public bool rotateStatus;
    
    // Start is called before the first frame update
    void Start()
    {
        rotateStatus = true;   
    }

    // Update revisa el valor de la bandera, en caso verdadero reanuda la rotaci�n
    void Update()
    {
        if (rotateStatus)
        {
            transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
        }else
            transform.Rotate(Vector3.up, rotateSpeed * 0);
    }

   //Funci�n que se encarga de activar y desactivar la rotacion del modelo
    public void ChangeRot()
    {
        rotateStatus = !rotateStatus;
    }
}
