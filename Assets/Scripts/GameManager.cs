using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour {

    private static GameManager instance;
    private int score;
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private TMP_Text scoreText;

    public bool isGameOver;

    public static GameManager Instance {
        get { return instance; }
    }

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0) && isGameOver) {
            RestartGame();
        }
    }

    public void GameOver() {
        isGameOver = true;
        gameOverText.SetActive(true);
    }

    private void RestartGame() { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void IncreaseScore() {
        score++;
        scoreText.text = score.ToString();
    }

}
