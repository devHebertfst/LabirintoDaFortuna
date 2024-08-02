using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int coins = 0;
    public float time;
    
    public float speedUpTime = 0f;
    public float shieldUpTime = 0f;
    public float jumpUpTime = 0f;
    public float bombUpTime = 0f;

    public Text[] powerUpTexts;
    public Text coinText;
    public Text timeText;

    public GameObject winPanel;
    public GameObject defeatPanel;
    public GameObject pausePanel;

    void Start() {
        time = 2f * 60f + 30f;
    }

    void WinGame() {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        winPanel.SetActive(true);
    }

    public void LoseGame(string message) {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        defeatPanel.GetComponentInChildren<Text>().text = message;
        defeatPanel.SetActive(true);
    }

    public void AddCoin() {
        coinText.text = (++coins).ToString() + "/100";

        if (coins >= 100) {
            WinGame();
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTime();

        UpdatePowerUpsDuration();

        OpenOrClosePausePanel();
    }

    void UpdateTime() {
        time -= Time.deltaTime;

        int minutes = (int) (time / 60);
        int seconds = (int) (time - (minutes * 60));

        string min = minutes.ToString().PadLeft(2, '0');
        string sec = seconds.ToString().PadLeft(2, '0');

        timeText.text = min + ":" + sec;

        if (minutes == 0 && seconds == 0) {
            LoseGame("O tempo acabou!");
        }
    }

    void UpdatePowerUpsDuration() {
        if (speedUpTime > 0f) {
            speedUpTime -= Time.deltaTime;
            if (speedUpTime < 0f) speedUpTime = 0f;

            powerUpTexts[0].text = ((int)speedUpTime).ToString();
        }

        if (shieldUpTime > 0f) {
            shieldUpTime -= Time.deltaTime;
            if (shieldUpTime < 0f) shieldUpTime = 0f;

            powerUpTexts[1].text = ((int)shieldUpTime).ToString();
        }

        if (jumpUpTime > 0f) {
            jumpUpTime -= Time.deltaTime;
            if (jumpUpTime < 0f) jumpUpTime = 0f;

            powerUpTexts[2].text = ((int)jumpUpTime).ToString();
        }

        if (bombUpTime > 0f) {
            bombUpTime -= Time.deltaTime;
            if (bombUpTime < 0f) bombUpTime = 0f;

            powerUpTexts[3].text = ((int)bombUpTime).ToString();
        }
    }

    void OpenOrClosePausePanel() {
        if (winPanel.activeSelf || defeatPanel.activeSelf) return;

        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!pausePanel.activeSelf) {
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                pausePanel.SetActive(true);
            } else {
                Time.timeScale = 1f;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                pausePanel.SetActive(false);
            }
        }
    }

    public void GoToMenu() {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
