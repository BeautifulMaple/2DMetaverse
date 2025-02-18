using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 자기를 참조하는 변수수
    static GameManager gameManager;
    public static GameManager Instance{get {return gameManager;}}

    UIManager uiManager;
    public UIManager UIManager {get {return uiManager;}}
    private int currenScore = 0;
    // 싱글턴 하나만 존재
    void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<UIManager>();
    }
    private void Start()
    {
        uiManager.UpadteScore(0);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        uiManager.SetRestart();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
        currenScore += score;
        Debug.Log("Score: ");
        uiManager.UpadteScore(currenScore);
    }

}
