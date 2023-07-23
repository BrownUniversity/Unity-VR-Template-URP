using UnityEngine;
using UnityEngine.InputSystem;

public class ToggleMenu : MonoBehaviour
{
    public InputActionReference toggleMenuReference = null;

    private void Awake()
    {
        toggleMenuReference.action.started += Toggle;
    }

    private void OnDestroy()
    {
        toggleMenuReference.action.started -= Toggle;
    }


    private void Toggle(InputAction.CallbackContext context)
    {
        bool isActive = gameObject.activeSelf;
        gameObject.SetActive(!isActive);
    }
}
