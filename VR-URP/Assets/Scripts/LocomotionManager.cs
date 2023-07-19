using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LocomotionManager : MonoBehaviour
{
    public GameObject leftTeleportRayInteractor;
    public GameObject rightTeleportRayInteractor;

    private TeleportationProvider _teleporationProvider;
    private ContinuousMoveProviderBase _continuousMoveProvider;

    private bool _teleportSelected = true;

    private void Start()
    {
        _teleporationProvider = GetComponent<TeleportationProvider>();
        _continuousMoveProvider = GetComponent<ContinuousMoveProviderBase>();

        SwitchLocomotion(_teleportSelected);
    }

    public void SwitchLocomotion(bool locomotionValue) {
        _teleportSelected = locomotionValue;

        if(_teleportSelected)
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

    public void ToggleLocomotion()
    {
        _teleportSelected = !_teleportSelected;
        SwitchLocomotion(_teleportSelected);
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
