using System;
using UnityEngine;

public class OrientToCamera : MonoBehaviour
{
    public GameObject targetObject;
    public GameObject userCamera;
    public float distanceFromUser = 2.0f;
    public float heightFromGround = 1.5f;

    private bool _objectActive;

    public void Toggle()
    {
        _objectActive = !_objectActive;

        if (_objectActive)
            UpdateOrientation();

        targetObject.SetActive(_objectActive);
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
