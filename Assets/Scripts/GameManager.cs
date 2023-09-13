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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // ���� �����ִ� ���� �ٽ� �ε��ϴ� �ڵ�
            // Restart the Game ���� �׳� ����� �ع�����
        }
    }

    public void AddScore(int newScore)
    {
        if (IsGameOver)
            return;

        score += newScore;
        scoreText.text = $"SCORE : {score}"; //���� �߰��� ���� ������Ʈ
    }

    public void OnPlayerDead()
    {
        IsGameOver = true;
        gameOverText.SetActive(true);
    }
}
