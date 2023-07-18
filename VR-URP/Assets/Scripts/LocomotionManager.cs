using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class LocomotionManager : MonoBehaviour
{
    public GameObject leftTeleportRayInteractor;
    public GameObject rightTeleportRayInteractor;

    public InputActionReference teleportActivationReference;

    private TeleportationProvider _teleporationProvider;
    private ContinuousMoveProviderBase _continuousMoveProvider;

    private void Start()
    {
        _teleporationProvider = GetComponent<TeleportationProvider>();
        _continuousMoveProvider = GetComponent<ContinuousMoveProviderBase>();
    }

    public void SwitchLocomotion(bool locomotionValue)
    {
        if(locomotionValue)
        {
            ContinuousSetActive(false);
            TeleportSetActive(true);
        }
        else
        {
            TeleportSetActive(false);
            ContinuousSetActive(true);
        }
    }

    private void ContinuousSetActive(bool active)
    {
        _continuousMoveProvider.enabled = active;
    }

    private void TeleportSetActive(bool active)
    {
        leftTeleportRayInteractor.SetActive(active);
        rightTeleportRayInteractor.SetActive(active);
        _teleporationProvider.enabled = active;
    }

}
