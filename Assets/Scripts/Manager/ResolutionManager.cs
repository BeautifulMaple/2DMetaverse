using UnityEngine;
using UnityEngine.SceneManagement;

public class ResolutionManager : MonoBehaviour
{
    void Start()
    {
        SetResolutionForCurrentScene();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SetResolutionForCurrentScene();
    }

    private void SetResolutionForCurrentScene()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "TheStack")
        {
            SetPortraitMode();
        }
        else
        {
            SetLandscapeMode();
        }
    }

    private void SetLandscapeMode()
    {
        Screen.orientation = ScreenOrientation.Landscape;
        Screen.SetResolution(1920, 1080, true);
    }

    private void SetPortraitMode()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        Screen.SetResolution(1080, 1920, true);
    }
}
