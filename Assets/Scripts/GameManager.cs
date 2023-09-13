using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool IsGameOver { get; private set; }

    public TextMeshProUGUI scoreText;
    public GameObject gameOverText;

    private int score = 0;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
            gameOverText.SetActive(false);
        }
        else
        {
            Debug.LogWarning("GameManager instance already exists.");
            Destroy(instance);
        }
    }

    private void Update()
    {
        if(IsGameOver && Input.GetMouseButtonDown(0)) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // 현재 열려있는 씬을 다시 로드하는 코드
            // Restart the Game 씬을 그냥 재시작 해버리게
        }
    }

    public void AddScore(int newScore)
    {
        if (IsGameOver)
            return;

        score += newScore;
        scoreText.text = $"SCORE : {score}"; //점수 추가될 때만 업데이트
    }

    public void OnPlayerDead()
    {
        IsGameOver = true;
        gameOverText.SetActive(true);
    }
}
