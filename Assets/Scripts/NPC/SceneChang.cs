using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneChang : MonoBehaviour
{
    [Header("UI ���")]
    [SerializeField] private GameObject NpcUI;          // ��ȣ�ۿ� UI �г�
    [SerializeField] private TMP_Text NpcUIText;        // ��ȭ UI �ؽ�Ʈ
    [SerializeField] private GameObject interactionText; // "G�� ���� ��ȣ�ۿ�" UI
    [SerializeField] private string gameSceneName = ""; // �̵��� ���� ��
    private bool isPlayerNearby = false;               // �÷��̾ NPC ��ó�� �ִ��� ����

    void Start()
    {
        if (NpcUI != null)
            NpcUI.SetActive(false); // �ʱ� UI ��Ȱ��

        if (interactionText != null)
            interactionText.SetActive(false); // "G�� ���� ��ȣ�ۿ�" ���� ����
    }

    void Update()
    {
        // �÷��̾ ��ó�� �ְ�, G Ű�� ������ UI ǥ��
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("GŰ �Է� ������!");
            if (NpcUIText != null)
            {
                NpcUIText.text = $"\"Do you want to go to the {gameSceneName} game?\"";
            }
            NpcUI.SetActive(true); // Panel Ȱ��ȭ
            interactionText.SetActive(false); // "G Ű" ���� ��Ȱ��ȭ
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
        NpcUI.SetActive(false); // Panel �ݱ�
        if (isPlayerNearby && interactionText != null)
        {
            interactionText.SetActive(true); // "G Ű" ���� �ٽ� Ȱ��ȭ
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNearby = true;
            if (interactionText != null)
            {
                interactionText.SetActive(true); // "G�� ���� ��ȣ�ۿ�" ���� ǥ��
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNearby = false;
            NpcUI.SetActive(false); // UI �ݱ�
            if (interactionText != null)
            {
                interactionText.SetActive(false); // "G Ű" ���� �����
            }
        }
    }
}
