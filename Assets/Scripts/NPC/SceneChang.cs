using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneChang : MonoBehaviour
{
    [SerializeField] private GameObject NpcUI;       // UI �г�
    [SerializeField] private TMP_Text NpcUIText;     // TextMeshPro UI �ؽ�Ʈ
    [SerializeField] private string gameSceneName = "";  // �̵��� ���� ��
    private bool isPlayerNearby = false;            // �÷��̾ �ֺ��� �ִ���

    void Start()
    {
        if (NpcUI != null)
            NpcUI.SetActive(false); // �ʱ� UI ��Ȱ��
    }

    void Update()
    {
        // �÷��̾ ��ó�� �ְ�, G Ű�� ������ ��ȣ�ۿ� UI ǥ��
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("GŰ �Է� ������!");
            if (NpcUIText != null)
            {
                NpcUIText.text = $"\"Do you want to go to the\n {gameSceneName}\" game?";
            }
            NpcUI.SetActive(true);
        }
    }

    // "��" ��ư Ŭ�� �� ���� ������ �̵�
    public void OnYesButton()
    {
        if (!string.IsNullOrEmpty(gameSceneName))
        {
            SceneManager.LoadScene(gameSceneName);
        }
    }

    // "�ƴϿ�" ��ư Ŭ�� �� UI �ݱ�
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
            NpcUI.SetActive(false); // ������ ����� UI�� ����
        }
    }
}
