using UnityEngine;
using UnityEngine.InputSystem;

enum Direction
{
    Up,
    Down,
    Left,
    Right
}

public class Player : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private float moveSpeed;

    [Header("Input Actions")]
    [SerializeField] private InputActionReference moveActionReference;

    private void OnEnable() => moveActionReference.action.Enable();
    private void OnDisable() => moveActionReference.action.Disable();

    private Direction currentDirection = Direction.Right;


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
        if (moveInput.x > 0 && currentDirection != Direction.Left)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            currentDirection = Direction.Right;
        }
        else if (moveInput.x < 0 && currentDirection != Direction.Right)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            currentDirection = Direction.Left;
        }
        else if (moveInput.y > 0 && currentDirection != Direction.Down)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
            currentDirection = Direction.Up;
        }
        else if (moveInput.y < 0 && currentDirection != Direction.Up)
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
            currentDirection = Direction.Down;
        }
    }
}
