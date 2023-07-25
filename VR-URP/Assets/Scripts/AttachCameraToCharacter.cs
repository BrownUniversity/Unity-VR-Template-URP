using Unity.XR.CoreUtils;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(XROrigin))]
public class AttachCameraToCharacter : MonoBehaviour
{
    CharacterController _characterController;
    XROrigin _xrOrigin;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _xrOrigin = GetComponent<XROrigin>();
    }

    private void FixedUpdate()
    {
        _characterController.height = _xrOrigin.CameraInOriginSpaceHeight + 0.15f;

        //World to local space
        var centerPoint = transform.InverseTransformPoint(_xrOrigin.Camera.transform.position);
        _characterController.center = new Vector3(
            centerPoint.x,
            (_characterController.height / 2) + _characterController.skinWidth,
            centerPoint.z);

        //Imperceptable jitter to stop character moving through walls
        _characterController.Move(new Vector3(0.001f, 0.001f, 0.001f));
        _characterController.Move(new Vector3(-0.001f, -0.001f, -0.001f));
    }

}
