using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveModel : MonoBehaviour
{
    public GameObject ARObject;
    //public GameObject objectRotate;

    //public float rotateSpeed = 50f;
    //bool rotateStatus = false;

    [SerializeField] private Camera aRCamera;
    private bool isARObjectSelected;
    private string tagARObjects = "ARObject";
    private Vector2 initialTouchPos;

    [SerializeField] private float speedMovement = 4.0f;
    [SerializeField] private float speedRotation = 10.0f;
    [SerializeField] private float scaleFactor = 0.1f;

    private float screenFactor = 0.001f;

    private float touchDis;
    private Vector2 touchPosDiff;

    private float rotationTol = 1.5f;
    private float scaleTol = 25.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touchOne = Input.GetTouch(0);

            if (Input.touchCount == 1)
            {

                if (touchOne.phase == TouchPhase.Began)
                {
                    initialTouchPos = touchOne.position;
                    isARObjectSelected = CheckTouchOnArObject(initialTouchPos);
                }
                if (touchOne.phase == TouchPhase.Moved && isARObjectSelected)
                {
                    Vector2 diffPosition = (touchOne.position - initialTouchPos) * screenFactor;

                    ARObject.transform.position = ARObject.transform.position +
                        new Vector3(diffPosition.x * speedMovement, diffPosition.y * speedMovement, 0);

                    initialTouchPos = touchOne.position;
                }

            }

            if (Input.touchCount == 2)
            {
                Touch touchTwo = Input.GetTouch(1);
                if (touchOne.phase == TouchPhase.Began || touchTwo.phase == TouchPhase.Began)
                {
                    touchPosDiff = touchTwo.position - touchOne.position;
                    touchDis = Vector2.Distance(touchTwo.position, touchOne.position);

                }

                if (touchOne.phase == TouchPhase.Moved || touchTwo.phase == TouchPhase.Moved)
                {
                    Vector2 currentTouchPosDiff = touchTwo.position - touchOne.position;
                    float currentTouchDis = Vector2.Distance(touchTwo.position, touchOne.position);

                    float diffDis = currentTouchDis - touchDis;

                    if (Mathf.Abs(diffDis) > scaleTol)
                    {
                        Vector3 newScale = ARObject.transform.localScale + Mathf.Sign(diffDis) * Vector3.one * scaleFactor;
                        ARObject.transform.localScale = Vector3.Lerp(ARObject.transform.localScale, newScale, 0.05f);
                    }

                    float angle = Vector2.SignedAngle(touchPosDiff, currentTouchPosDiff);

                    if (Mathf.Abs(angle) > rotationTol)
                    {
                        ARObject.transform.rotation = Quaternion.Euler(0, ARObject.transform.rotation.eulerAngles.y - Mathf.Sign(angle) * speedMovement, 0);

                    }

                    touchDis = currentTouchDis;
                    touchPosDiff = currentTouchPosDiff;
                }

            }
        }
    }
    private bool CheckTouchOnArObject(Vector2 touchPosition)
    {
        Ray ray = aRCamera.ScreenPointToRay(touchPosition);

        if (Physics.Raycast(ray, out RaycastHit hitARObject))
        {
            if (hitARObject.collider.CompareTag(tagARObjects))
            {
                ARObject = hitARObject.transform.gameObject;
                return true;
            }
        }

        return false;
    }
}

