using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{    
    private float _zoomSpeed = 10;
    private Camera _camera;
    private List<Transform> targets = new List<Transform>();
    private Transform currentTarget;
    private float initialDistance;

    // эти переменные для вращения камерой
    private float currentAngleX = 0f;
    private float currentAngleY = 0f; 

    public Vector3 initialPosition;
    public float rotationSpeed = 5.0f;
    public float distance = 5.0f;
    public float sensitivity = 2.0f;

    void Start() 
    {
        _camera = Camera.main;
        initialDistance = distance;
        initialPosition = transform.position;
    }

    void Update()
    {
        if (currentTarget == null)
        {
            HandleCameraMovementAndRotation();
        }
        else
        {
            HandleCameraMovementAroundSelectedObject();
            HandleCameraZoom();
        }
    }
    
    public void returnPos() 
    {
        _camera.transform.rotation = Quaternion.identity;
        transform.position = initialPosition;
        _camera.fieldOfView = 60.0f;
    }

    public void SetTarget(Transform newTarget)
    {
        currentTarget = newTarget;

        if (currentTarget != null)
        {
            UpdateCameraPositionAndRotation();
        }
    }

    private void UpdateCameraPositionAndRotation()
    {
        if (currentTarget != null)
        {
            Vector3 newPosition = currentTarget.position + currentTarget.forward * -100.0f;
            transform.position = newPosition;
            transform.LookAt(currentTarget);
        }
    }

    private void HandleCameraMovementAndRotation()
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
    }

    private void HandleCameraMovementAroundSelectedObject()
    {
        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

            currentAngleX += mouseX;
            currentAngleY -= mouseY;

            // Ограничиваем вертикальный угол вращения
            currentAngleY = Mathf.Clamp(currentAngleY, -80.0f, 80.0f);

            Quaternion rotation = Quaternion.Euler(currentAngleY, currentAngleX, 0);
            Vector3 direction = rotation * new Vector3(0, 0, -initialDistance);
            transform.position = currentTarget.position + direction * initialDistance;

            transform.LookAt(currentTarget);
        }
    }

    private void HandleCameraZoom()
    {
        if (_camera.orthographic)
        {
            _camera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * _zoomSpeed;
            _camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize, 1f, 20f);
        }
        else
        {
            _camera.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * _zoomSpeed;
            _camera.fieldOfView = Mathf.Clamp(_camera.fieldOfView, 10f, 180f);
        }
    }
}

