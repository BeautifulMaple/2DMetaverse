using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResolutionManager : MonoBehaviour
{
    private static ResolutionManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // �� ���� �� ����
            SceneManager.sceneLoaded += OnSceneLoaded; // �� ���� �̺�Ʈ ���
            StartCoroutine(ChangeResolutionForCurrentScene()); // ù �� �ػ� ����
        }
        else
        {
            Destroy(gameObject); // �ߺ� ����
        }
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(ChangeResolutionForCurrentScene()); // �� ���� �� �ػ� ����
    }

    private IEnumerator ChangeResolutionForCurrentScene()
    {
        yield return new WaitForSeconds(0.2f); // ��� ��� �� ����

        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "TheStack")
        {
            Screen.SetResolution(720, 1280, false);
        }
        else if (sceneName == "FlappyPlane" || sceneName == "SampleScene")
        {
            Screen.SetResolution(1920, 1080, false);
        }

    }
}
