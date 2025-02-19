using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CharacterColorChanger : MonoBehaviour
{
    [SerializeField] private Renderer playerRenederer;
    [SerializeField] private Image previewImage;
    [Header("Slider")]
    [SerializeField] private Slider rSlider, gSlider, bSlider, aSlider;

    [Header("Input")]
    [SerializeField] private TMP_InputField rInput, gInput, bInput, aInput;

    private Color currentColor;

    void Start()
    {
        // 슬라이더 값 변경 시 이벤트 연결하기
        rSlider.onValueChanged.AddListener(UpdateColorFromSlider);
        gSlider.onValueChanged.AddListener(UpdateColorFromSlider);
        bSlider.onValueChanged.AddListener(UpdateColorFromSlider);
        aSlider.onValueChanged.AddListener(UpdateColorFromSlider);

        // 입력 필드 값 변경 시 이벤트 연결
        rInput.onEndEdit.AddListener(UpdateColorFromInput);
        gInput.onEndEdit.AddListener(UpdateColorFromInput);
        bInput.onEndEdit.AddListener(UpdateColorFromInput);
        aInput.onEndEdit.AddListener(UpdateColorFromInput);

        // 초기값 적용
        currentColor = playerRenederer.material.color;
        ApplyColorToUI();
    }

    private void ApplyColorToUI()
    {
        rSlider.value = currentColor.r;
        gSlider.value = currentColor.g;
        bSlider.value = currentColor.b;
        aSlider.value = currentColor.a;

        rInput.text = Mathf.RoundToInt(currentColor.r * 255).ToString();
        gInput.text = Mathf.RoundToInt(currentColor.g * 255).ToString();
        bInput.text = Mathf.RoundToInt(currentColor.b * 255).ToString();
        aInput.text = Mathf.RoundToInt(currentColor.a * 255).ToString();

        previewImage.color = currentColor;
    }

    private void UpdateColorFromInput(string value)
    {   // r,g,b,a 입력 값
        float r = Mathf.Clamp01(float.Parse(rInput.text) / 255f);
        float g = Mathf.Clamp01(float.Parse(rInput.text) / 255f);
        float b = Mathf.Clamp01(float.Parse(rInput.text) / 255f);
        float a = Mathf.Clamp01(float.Parse(rInput.text) / 255f);

        rSlider.value = r;
        gSlider.value = g;
        bSlider.value = b;
        aSlider.value = a;

        currentColor = new Color(r, g, b, a);
        ApplyColorToUI();
    }

    private void UpdateColorFromSlider(float value)
    {
        currentColor = new Color(rSlider.value, gSlider.value, bSlider.value, aSlider.value);
    }
    private void ApplyColor()
    {
        playerRenederer.material.color = currentColor;
        previewImage.color = currentColor;
    }
}
