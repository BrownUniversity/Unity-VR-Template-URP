using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

// Developed following this tutorial: https://www.youtube.com/watch?v=wGvh7Suo1h4

public class TeleportController : MonoBehaviour
{
    public GameObject directController;
    public GameObject teleportController;

    [Space]
    public InputActionReference teleportActivationReference;
    public UnityEvent onTeleportActivate;
    public UnityEvent onTeleportCancel;

    private void Start()
    {
        teleportActivationReference.action.performed += TeleportModeActivate;
        teleportActivationReference.action.canceled += TeleportModeCancel;
    }

    private void TeleportModeCancel(InputAction.CallbackContext context) => Invoke("DeactivateTeleport", .1f);

    private void DeactivateTeleport() => onTeleportCancel.Invoke();

    private void TeleportModeActivate(InputAction.CallbackContext context) => onTeleportActivate.Invoke();
}
