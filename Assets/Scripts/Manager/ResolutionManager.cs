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
            DontDestroyOnLoad(gameObject); // 씬 변경 시 유지
            SceneManager.sceneLoaded += OnSceneLoaded; // 씬 변경 이벤트 등록
            StartCoroutine(ChangeResolutionForCurrentScene()); // 첫 씬 해상도 설정
        }
        else
        {
            Destroy(gameObject); // 중복 방지
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
        StartCoroutine(ChangeResolutionForCurrentScene()); // 씬 변경 후 해상도 적용
    }

    private IEnumerator ChangeResolutionForCurrentScene()
    {
        yield return new WaitForSeconds(0.2f); // 잠깐 대기 후 적용

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
