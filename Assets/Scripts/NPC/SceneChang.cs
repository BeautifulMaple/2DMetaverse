using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneChang : MonoBehaviour
{
    [SerializeField] private GameObject NpcUI;       // UI 패널
    [SerializeField] private TMP_Text NpcUIText;     // TextMeshPro UI 텍스트
    [SerializeField] private string gameSceneName = "";  // 이동할 게임 씬
    private bool isPlayerNearby = false;            // 플레이어가 주변에 있는지

    void Start()
    {
        if (NpcUI != null)
            NpcUI.SetActive(false); // 초기 UI 비활성
    }

    void Update()
    {
        // 플레이어가 근처에 있고, G 키를 누르면 상호작용 UI 표시
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("G키 입력 감지됨!");
            if (NpcUIText != null)
            {
                NpcUIText.text = $"\"Do you want to go to the\n {gameSceneName}\" game?";
            }
            NpcUI.SetActive(true);
        }
    }

    // "네" 버튼 클릭 시 게임 씬으로 이동
    public void OnYesButton()
    {
        if (!string.IsNullOrEmpty(gameSceneName))
        {
            SceneManager.LoadScene(gameSceneName);
        }
    }

    // "아니요" 버튼 클릭 시 UI 닫기
    public void OnNoButton()
    {
        NpcUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNearby = false;
            NpcUI.SetActive(false); // 범위를 벗어나면 UI도 숨김
        }
    }
}
