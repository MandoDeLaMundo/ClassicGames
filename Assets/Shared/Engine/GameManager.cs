using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] GameObject menuActive;
    [SerializeField] GameObject menuPause;

    [SerializeField] private InputActionReference cancelActionReference;

    public bool isPaused;

    float timeScaleOrig;

    private void OnEnable() => cancelActionReference.action.Enable();
    private void OnDisable() => cancelActionReference.action.Disable();

    private void Awake()
    {
        instance = this;
        timeScaleOrig = Time.timeScale;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        if (cancelActionReference.action.WasPressedThisFrame())
        {
            if (menuActive == null)
            {
                PauseGame();
                menuActive = menuPause;
                menuActive.SetActive(isPaused);
            }
            else if (menuActive == menuPause)
            {
                ResumeGame();
            }
        }
    }

    public void PauseGame()
    {
        isPaused = !isPaused;
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ResumeGame()
    {
        isPaused = !isPaused;
        Time.timeScale = timeScaleOrig;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        menuActive.SetActive(false);
        menuActive = null;
    }
}
