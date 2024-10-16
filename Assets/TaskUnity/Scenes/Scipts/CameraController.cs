using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class CameraController : MonoBehaviour
//{
//    private List<Transform> targets = new List<Transform>();
//    public float distance = 5.0f;
//    public float sensitivity = 2.0f; // Чувствительность мыши
//    public float verticalSpeed = 2.0f; // Скорость вертикального движения
//    private Transform currentTarget;
//    void Update()
//    {
//        if(Input.GetMouseButtonDown(0))
//        {
//            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//            RaycastHit hit;
//            if (Physics.Raycast(ray, out hit))
//            {
//                foreach (Transform target in targets)
//                {
//                    if (target == hit.transform)
//                    {
//                        SetTarget(target);
//                        break; 
//                    }
//                }
//            }
//        }

//        // Вращение камеры вокруг объекта
//        if (currentTarget != null)
//        {
//            if (Input.GetMouseButton(1)) 
//            {
//                float horizontal = Input.GetAxis("Mouse X") * sensitivity;
//                float vertical = Input.GetAxis("Mouse Y") * sensitivity;

//                transform.RotateAround(currentTarget.position, Vector3.up, horizontal);
//                transform.RotateAround(currentTarget.position, transform.right, -vertical);
//            }

//            float verticalInput = Input.GetAxis("Mouse Y");
//            transform.Translate(Vector3.up * verticalInput * verticalSpeed * Time.deltaTime);
//        }
//    }

//    public void SetTarget(Transform newTarget)
//    {
//        currentTarget = newTarget;
//        // Перемещение камеры к целевому объекту

//        if (currentTarget != null)
//        {
//            Vector3 newPosition = currentTarget.position - currentTarget.forward * distance;
//            transform.position = newPosition;
//            transform.LookAt(currentTarget.position);
//        }
//    }

//    public void AddTarget(Transform newTarget) 
//    {
//        targets.Add(newTarget);
//        SetTarget(newTarget);
//    }
//}


public class CameraController : MonoBehaviour
{
    public float distance = 5.0f;
    public float sensitivity = 2.0f;

    private float _zoomSpeed = 10;

    [SerializeField] private GameObject _itemInfoCanvas;
    private Camera _camera;
    private List<Transform> targets = new List<Transform>();
    private Transform currentTarget;

    void Start() 
    {
        _camera = Camera.main;
    }


    void Update()
    {
        if (!_itemInfoCanvas.activeSelf)
        {
            float mouseY = Input.GetAxis("Mouse Y");
            if (Input.GetMouseButton(0))
            {
                transform.RotateAround(transform.position, Vector3.right, mouseY * sensitivity);
            }

            if (_camera.orthographic)
            {
                _camera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * _zoomSpeed;
            }
            else
            {
                _camera.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * _zoomSpeed;
            }

            if (currentTarget != null)
            {
                transform.LookAt(currentTarget.position);
            }
        }
    }


    public void AddTarget(Transform newTarget)
    {
        targets.Add(newTarget);
        SetTarget(newTarget);
        // Set the current target to the newly added target
    }

    public void SetTarget(Transform newTarget)
    {
        currentTarget = newTarget;

        // Move the camera to the new target if (currentTarget != null)
        {
            Vector3 newPosition = currentTarget.position + currentTarget.forward * distance;
            transform.position = newPosition;
            transform.LookAt(currentTarget.position);
        }
    }
}

