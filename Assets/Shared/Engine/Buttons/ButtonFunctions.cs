using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
    public void TestButton()
    {
        Debug.Log("Button Pressed!");
    }

    public void LoadScene(string sceneName)
    {
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
