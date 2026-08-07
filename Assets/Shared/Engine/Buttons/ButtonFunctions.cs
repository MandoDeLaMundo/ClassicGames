using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
    public void TestButton()
    {
        Debug.Log("Button Pressed!");
    }

    public void LoadScene(string sceneName)
    {
        if (GameManager.instance.isPaused)
        {
            GameManager.instance.UnpauseBeforeSwitchingScene();
        }

        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
