using System;
using UnityEngine;

public class OrientToCamera : MonoBehaviour
{
    public GameObject targetObject;
    public GameObject userCamera;
    public float distanceFromUser = 2.0f;
    public float heightFromGround = 1.5f;
    public bool reverseObject;

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
            UpdateOrientation(GetNewPosition());
    }

    public void Toggle()
    {
        //If the object is disabled, enable it...
        if(!targetObject.activeSelf)
        {
            targetObject.SetActive(!targetObject.activeSelf);
            return;
        }

        // ...if the object is enabled check is position
        Vector3 newPosition = GetNewPosition();
        float distance = Vector3.Distance(newPosition, targetObject.transform.position);

        if(distance > 0.75)
        {
            UpdateOrientation(newPosition);
        } else
        {
            targetObject.SetActive(!targetObject.activeSelf);
        }
    }

    private Vector3 GetNewPosition()
    {
        Vector3 newPosition = userCamera.transform.TransformPoint(0, 0, distanceFromUser);
        newPosition.y = userCamera.transform.position.y;

        return newPosition;
    }


    private void UpdateOrientation(Vector3 newPosition)
    {
        targetObject.transform.position = newPosition;

        targetObject.transform.LookAt(userCamera.transform);
        if(reverseObject )
            targetObject.transform.Rotate(0, 180.0f, 0);
    }
}
