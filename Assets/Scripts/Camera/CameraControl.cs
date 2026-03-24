using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Cinemachine;

public class CameraControl : MonoBehaviour
{
    private CinemachineInputAxisController axisController;

    void Start()
    {
        axisController = GetComponent<CinemachineInputAxisController>();
    }

    void Update()
    {
        if (Mouse.current.rightButton.isPressed)
        {
            axisController.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            axisController.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}