using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizationUIManager : MonoBehaviour
{
    [SerializeField] private GameObject colorPanel; // 색상 변경
    [SerializeField] private GameObject exteriorPanel;  // 외형 변경
    [SerializeField] private Button colorButton; // 색상 변경 버튼
    [SerializeField] private Button exteriorButton;  // 외형 변경 버튼
    // Start is called before the first frame update
    void Start()
    {
        colorButton.onClick.AddListener(ShowColorPenel);
        exteriorButton.onClick.AddListener(ShowExeriorPenel);

    }

    private void ShowExeriorPenel()
    {
        colorPanel.SetActive(true);
        exteriorPanel.SetActive(false);
    }

    private void ShowColorPenel()
    {
        colorPanel.SetActive(false);
        exteriorPanel.SetActive(true);
    }

}
