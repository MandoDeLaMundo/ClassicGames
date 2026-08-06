using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private float moveSpeed;

    [Header("Input Actions")]
    [SerializeField] private InputActionReference moveActionReference;

    private void OnEnable() => moveActionReference.action.Enable();
    private void OnDisable() => moveActionReference.action.Disable();

    private void Awake()
    {
        
    }

    void Update()
    {
        if (GameManager.instance.isPaused) return;

        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        
        if (moveActionReference.action.triggered)
        {
            Vector2 moveInput = moveActionReference.action.ReadValue<Vector2>();
            RotatePlayer(moveInput);
        }
    }

    void RotatePlayer(Vector2 moveInput)
    {
        if (moveInput.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (moveInput.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (moveInput.y > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (moveInput.y < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
    }
}
