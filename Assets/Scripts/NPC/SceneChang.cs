using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneChang : MonoBehaviour
{
    [Header("UI 요소")]
    [SerializeField] private GameObject NpcUI;          // 상호작용 UI 패널
    [SerializeField] private TMP_Text NpcUIText;        // 대화 UI 텍스트
    [SerializeField] private GameObject interactionText; // "G를 눌러 상호작용" UI
    [SerializeField] private string gameSceneName = ""; // 이동할 게임 씬
    private bool isPlayerNearby = false;               // 플레이어가 NPC 근처에 있는지 여부

    void Start()
    {
        if (NpcUI != null)
            NpcUI.SetActive(false); // 초기 UI 비활성

        if (interactionText != null)
            interactionText.SetActive(false); // "G를 눌러 상호작용" 문구 숨김
    }

    void Update()
    {
        // 플레이어가 근처에 있고, G 키를 누르면 UI 표시
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("G키 입력 감지됨!");
            if (NpcUIText != null)
            {
                NpcUIText.text = $"\"Do you want to go to the {gameSceneName} game?\"";
            }
            NpcUI.SetActive(true); // Panel 활성화
            interactionText.SetActive(false); // "G 키" 문구 비활성화
        }
    }

    public void OnYesButton()
    {
        if (!string.IsNullOrEmpty(gameSceneName))
        {
            SceneManager.LoadScene(gameSceneName);
        }
    }

    public void OnNoButton()
    {
        NpcUI.SetActive(false); // Panel 닫기
        if (isPlayerNearby && interactionText != null)
        {
            interactionText.SetActive(true); // "G 키" 문구 다시 활성화
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNearby = true;
            if (interactionText != null)
            {
                interactionText.SetActive(true); // "G를 눌러 상호작용" 문구 표시
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNearby = false;
            NpcUI.SetActive(false); // UI 닫기
            if (interactionText != null)
            {
                interactionText.SetActive(false); // "G 키" 문구 숨기기
            }
        }
    }
}
