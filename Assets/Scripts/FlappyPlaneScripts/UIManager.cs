using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;
    // Start is called before the first frame update
    void Start()
    {
        if(restartText == null)
            Debug.LogError("restart text is null");
        if(scoreText == null)
            Debug.LogError("restart text is null");
        // 게임 오브젝트 끄기기
        restartText.gameObject.SetActive(false);

    }

    public void SetRestart()
    {
        restartText.gameObject.SetActive(true);
    }
    public void UpadteScore(int score)
    {
        scoreText.text = score.ToString();
    }

}
