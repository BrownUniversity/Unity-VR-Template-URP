using System;
using UnityEngine;

public class OrientToCamera : MonoBehaviour
{
    public GameObject targetObject;
    public GameObject userCamera;
    public float distanceFromUser = 2.0f;
    public float heightFromGround = 1.5f;

    private bool _objectActive;

    private void Awake()
    {
        _objectActive = targetObject.activeSelf;
    }

    private void Update()
    {
        if (_objectActive == targetObject.activeSelf)
            return;
        
        _objectActive = targetObject.activeSelf;

        if (_objectActive)
            UpdateOrientation();
    }

    public void Toggle()
    {
        targetObject.SetActive(!targetObject.activeSelf);
    }


    private void UpdateOrientation()
    {
        Vector3 newPosition = userCamera.transform.TransformPoint(0, 0, distanceFromUser);
        newPosition.y = userCamera.transform.position.y;
        targetObject.transform.position = newPosition;

        targetObject.transform.position = newPosition;
        targetObject.transform.LookAt(userCamera.transform);
        targetObject.transform.Rotate(0, 180.0f, 0);
    }
}
