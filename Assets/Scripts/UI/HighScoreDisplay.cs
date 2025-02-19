using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreDisplay : MonoBehaviour
{
    [SerializeField] private List<TMP_Text> scoreTexts;
    [SerializeField] private List<string> gameKeys;  // PlayerPrefs에서 가져올 키 리스트
    // Start is called before the first frame update
    void Start()
    {
        if (scoreTexts.Count != gameKeys.Count)
        {
            Debug.LogError("scoreTexts와 gameKeys의 개수가 일치하지 않습니다!");
            return;
        }

        for (int i = 0; i < gameKeys.Count; i++)
        {
            int highScore = PlayerPrefs.GetInt(gameKeys[i], 0);
            Debug.Log($"{gameKeys[i]} : {highScore}");
            scoreTexts[i].text = $"{gameKeys[i]} : {highScore}";
        }
    }

}
