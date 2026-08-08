using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private float moveInterval;

    [Header("Input Actions")]
    [SerializeField] private InputActionReference moveActionReference;

    private void OnEnable() => moveActionReference.action.Enable();
    private void OnDisable() => moveActionReference.action.Disable();

    private Vector2 rawInput;
    private float moveTimer;

    private Vector2Int direction = Vector2Int.right;
    private Vector2Int gridPosition;

    void Update()
    {
        if (GameManager.instance.isPaused) return;

        rawInput = moveActionReference.action.ReadValue<Vector2>();

        MovePlayer(rawInput);
    }

    void MovePlayer(Vector2 moveInput)
    {
        if (moveInput.x > 0 && direction != Vector2Int.left)
        {
            direction = Vector2Int.right;
        }
        else if (moveInput.x < 0 && direction != Vector2Int.right)
        {
            direction = Vector2Int.left;
        }
        else if (moveInput.y > 0 && direction != Vector2Int.down)
        {
            direction = Vector2Int.up;
        }
        else if (moveInput.y < 0 && direction != Vector2Int.up)
        {
            direction = Vector2Int.down;
        }

        moveTimer += Time.deltaTime;

        if (moveTimer >= moveInterval)
        {
            gridPosition += direction;
            transform.position = new Vector3(gridPosition.x, gridPosition.y, 0);
            moveTimer = 0f;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Border"))
        {
            GameManager.instance.PauseGame();
            Debug.Log("Border hit!");
        }
    }
}
