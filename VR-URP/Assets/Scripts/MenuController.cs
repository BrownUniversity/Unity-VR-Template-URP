using System;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject menu;
    public GameObject userCamera;
    public float distanceFromUser = 2.0f;
    public float heightFromGround = 1.5f;

    private bool _menuDisplayed;

    public void ToggleMenu()
    {
        _menuDisplayed = !_menuDisplayed;

        if (_menuDisplayed)
            OrientTowardViewer();

        ActivateMenu(_menuDisplayed);
    }

    public void Cancel() => ActivateMenu(false);

    public void Submit()
    {

        ActivateMenu(false);
    }

    private void ActivateMenu( bool activate )
    {
        if (activate)
        {
            menu.SetActive(activate);
        } else
        {
            menu.SetActive(activate);
        }
            
    }

    private void OrientTowardViewer()
    {
        Vector3 newPosition = userCamera.transform.TransformPoint(0, 0, distanceFromUser);
        newPosition.y = userCamera.transform.position.y;
        menu.transform.position = newPosition;

        menu.transform.position = newPosition;
        menu.transform.LookAt(userCamera.transform);
        menu.transform.Rotate(0, 180.0f, 0);
    }
}
