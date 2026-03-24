using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float runSpeed = 3f;
    public float rotationSpeed = 80f;
    public Animator animator;
    private float x, y;
    private Rigidbody rb;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null) return;

        x = 0;
        if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed) x = -1;
        if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed) x = 1;

        y = 0;
        if (keyboard.wKey.isPressed || keyboard.upArrowKey.isPressed) y = 1;
        if (keyboard.sKey.isPressed || keyboard.downArrowKey.isPressed) y = -1;

        transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);

        transform.Translate(0, 0, y * Time.deltaTime * runSpeed);

        if (animator != null)
        {
            animator.SetFloat("VelX", x, 0.1f, Time.deltaTime);
            animator.SetFloat("VelY", y, 0.1f, Time.deltaTime);
        }
    }
}