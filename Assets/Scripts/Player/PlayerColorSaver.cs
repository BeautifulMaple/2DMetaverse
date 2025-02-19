using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerColorSaver : MonoBehaviour
{
    [SerializeField] private PlayerColorChanger character;
    private const string ColorKey = "PlayerColor";

    private void Start()
    {
        LoadColor();
    }

    public void SaveColor(Color color)
    {
        PlayerPrefs.SetFloat(ColorKey + "_R", color.r);
        PlayerPrefs.SetFloat(ColorKey + "_G", color.g);
        PlayerPrefs.SetFloat(ColorKey + "_B", color.b);
        PlayerPrefs.Save();
    }

    public void LoadColor()
    {
        if (PlayerPrefs.HasKey(ColorKey + "_R"))
        {
            float r = PlayerPrefs.GetFloat(ColorKey + "_R");
            float g = PlayerPrefs.GetFloat(ColorKey + "_G");
            float b = PlayerPrefs.GetFloat(ColorKey + "_B");

            Color loadedColor = new Color(r, g, b);
            character.ChangeColor(loadedColor);
        }
    }
}
