using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARInteractionManager : MonoBehaviour
{
    [SerializeField] private Camera ARCamera;
    private ARRaycastManager aRRaycastManager;

    //Lista de colisiones con objetos en el ambiente de RA
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    //Objeto que usamos como ayuda visual para colocar objetos
    private GameObject aRPointer;

    //Modelos 3D, el primero es el elegido, el segundo es para cuando seleccionamos uno ya existente
    private GameObject item3DModel;
    private GameObject itemSelected;

    //Variables Booleanas que nos indican si nos encontramos en la posicion inicial, si hemos hecho tap sobre la UI o si se ha hecho tap sobre un modelo 3D
    private bool isInitialposition;
    private bool isOverUI;
    private bool isOver3DModel;

    private Vector2 initialTouchPos;
    

    /*
     * Funcion que cumple el rol de un setter 
     */
    public GameObject Item3DModel
    {
        set
        {
            item3DModel = value;
            item3DModel.transform.position = aRPointer.transform.position;
            item3DModel.transform.parent = aRPointer.transform;
            isInitialposition = true;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        aRPointer = transform.GetChild(0).gameObject;
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
        AppManager.instance.OnMainMenu += SetComponentPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //Verificamos si que la posicion de un objeto sea la inicial
        if (isInitialposition)
        {

            Vector2 middlePointScreen = new Vector2(Screen.width / 2, Screen.height / 2);
            aRRaycastManager.Raycast(middlePointScreen, hits, TrackableType.Planes);
            
            //Verificamos si hay al menos una colision de RayCast
            if(hits.Count > 0)
            {
                //Establecemos la posicion y rotación del objeto en base al raycast
                transform.position = hits[0].pose.position;
                transform.rotation = hits[0].pose.rotation;
                aRPointer.SetActive(true);
                isInitialposition = false;
            }
        }

        //Verificamos si existe al menos un toque en pantalla
        if (Input.touchCount > 0)
        {
            //Asignamos el primer toque de pantalla a una variable
            Touch touchOne = Input.GetTouch(0);

            //Al momento del inicio del toque
            if(touchOne.phase == TouchPhase.Began)
            {
                var touchPosition = touchOne.position;

                //Preguntamos si el toque fue hecho sobre la UI o un modelo 3D
                isOverUI = isTapOverUI(touchPosition);
                isOver3DModel = isTapOverUI3DModel(touchPosition);
            }

            //Al momento del movimiento con el toque
            if(touchOne.phase == TouchPhase.Moved)
            {
                //Verificamos si algun raycast se encuentra haciendo una colision
                if(aRRaycastManager.Raycast(touchOne.position, hits, TrackableType.Planes))
                {
                    Pose hitPose = hits[0].pose;

                    //En caso de que el toque y movimiento sea a un modelo 3D y no se este tocando la UI, modificamos la ubicacion del modelo.
                    if (!isOverUI && isOver3DModel)
                    {
                        transform.position = hitPose.position;
                    }
                }
            }

            //En caso de que se realizen 2 toques en pantalla
            if(Input.touchCount == 2)
            {
                Touch TouchTwo = Input.GetTouch(1);

                //Al momento del inicio de los toques
                if (touchOne.phase == TouchPhase.Began || TouchTwo.phase == TouchPhase.Began)
                {
                    initialTouchPos = TouchTwo.position - touchOne.position;
                }

                //Al momento del movimiento con los toques
                if (touchOne.phase == TouchPhase.Moved || TouchTwo.phase == TouchPhase.Moved)
                {
                    //Realizamos un movimiento de rotacion del modelo seleccionado calculando el angulo de rotacion entre ambos toques
                    Vector2 currentTouchPos = TouchTwo.position - touchOne.position;
                    float angle = Vector2.SignedAngle(initialTouchPos, currentTouchPos);
                    item3DModel.transform.rotation = Quaternion.Euler(0, item3DModel.transform.eulerAngles.y - angle, 0);
                    initialTouchPos = currentTouchPos;
                }
            }

            //Verificamos si el toque fue sobre un modelo3D y no sobre la UI
            if (isOver3DModel && item3DModel == null && !isOverUI)
            {
                //En caso afirmativo, entramos al menú de posicionamiento de un modelo ya instanciado en una superficie.
                AppManager.instance.ARPosition();
                item3DModel = itemSelected;
                itemSelected = null;
                aRPointer.SetActive(true);
                transform.position = item3DModel.transform.position;
                item3DModel.transform.parent = aRPointer.transform;

            }
        }
    }

    /*
     * Funcion que nos dice si el toque en pantalla fue realizado sobre un objeto 3D instanciado en alguna superficie
     * @param touchPosition: Posicion del toque en pantalla realizado
     * @return Un valor booleando indicando el resultado de los if.
     */
    private bool isTapOverUI3DModel(Vector2 touchPosition)
    {
        Ray ray = ARCamera.ScreenPointToRay(touchPosition);
        if(Physics.Raycast(ray, out RaycastHit hit3DModel))
        {
            if (hit3DModel.collider.CompareTag("Component"))
            {
                itemSelected = hit3DModel.transform.gameObject;
                return true;
            }
        }
        return false;
    }

    /*
     * Funcion que nos dice si el toque en pantalla fue realizado sobre la UI 
     * @param touchPosition: Posicion del toque en pantalla realizado
     * @return Un valor booleando indicando si hubo un toque o no sobre la UI.
     */
    private bool isTapOverUI(Vector2 touchPosition)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(touchPosition.x, touchPosition.y);

        List<RaycastResult> result = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, result);

        return result.Count > 0;

    }

    /*
     * Funcion encargada de posicionar el modelo 3D en una posicion inicial
     */
    private void SetComponentPosition()
    {
        if(item3DModel != null)
        {
            item3DModel.transform.parent = null;
            aRPointer.SetActive(false);
            item3DModel = null;
        }
    }

    /*
     * Funcion encargada de eliminar objetos 3D de las superficies
     */
    public void DeleteItem()
    {
        Destroy(item3DModel);
        aRPointer.SetActive(false);
        AppManager.instance.MainMenu();
    }

}
