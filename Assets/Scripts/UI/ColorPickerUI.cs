using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPickerUI : MonoBehaviour
{
    [SerializeField] private PlayerColorChanger character;
    [SerializeField] private Button redButton;
    [SerializeField] private Button blueButton;
    [SerializeField] private Button greenButton;

    void Start()
    {
        redButton.onClick.AddListener(() => character.ChangeColor(Color.red));
        blueButton.onClick.AddListener(() => character.ChangeColor(Color.blue));
        greenButton.onClick.AddListener(() => character.ChangeColor(Color.green));
    }
}
