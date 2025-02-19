using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorChanger : MonoBehaviour
{
    [SerializeField] private SpriteRenderer playerSprite;

    public void ChangeColor(Color newColor)
    {
        if(playerSprite != null)
        {
            playerSprite.color = newColor;
        }
    }
}
