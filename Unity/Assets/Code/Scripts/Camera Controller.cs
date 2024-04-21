using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    public Camera mainCam;
    public Camera backsideCam;
    public Camera thirdPersonCam;

    public InputActionReference mainCamInput;
    public InputActionReference ThirdPersonCamInput;
    public InputActionReference backsideCamInput;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        float playerMovement = mainCamInput.action.ReadValue<float>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mainCamInput.action.ReadValue<float>() > 0) {
            onSwitchToMainCam();
        } else if (ThirdPersonCamInput.action.ReadValue<float>() > 0) {
            onSwitchToThirdPerson();
        } else if (backsideCamInput.action.ReadValue<float>() > 0) {
            onSwitchToBackendCam();
        }
    }

    void onSwitchToMainCam() {
        thirdPersonCam.enabled = false;
        backsideCam.enabled = false;
        mainCam.enabled = true;
    }
    void onSwitchToBackendCam() {
        mainCam.enabled = false;
        thirdPersonCam.enabled = false;
        backsideCam.enabled = true;
    }
    void onSwitchToThirdPerson() {
        mainCam.enabled = false;
        backsideCam.enabled = false;
        thirdPersonCam.enabled = true;
    }


}