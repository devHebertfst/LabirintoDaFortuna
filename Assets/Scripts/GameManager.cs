using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int coins = 0;
    public float time = 0f;
    
    public float speedUpTime = 0f;
    public float shieldUpTime = 0f;
    public float jumpUpTime = 0f;
    public float bombUpTime = 0f;

    public Text[] powerUpTexts;
    public Text coinText;
    public Text timeText;

    public void AddCoin() {
        coinText.text = (++coins).ToString();
    }

    // public void AddPowerUp(string powerUp, float duration) {
    //     switch (powerUp) {
    //         case "speedUp":
    //             speedUpTime = duration;
    //             break;
    //         case "shieldUp":
    //             shieldUpTime = duration;
    //             break;
    //         case "jumpUp":
    //             jumpUpTime = duration;
    //             break;
    //         case "bombUp":
    //             bombUpTime = duration;
    //             break;
    //         default:
    //             break;
    //     }
    // }

    // Update is called once per frame
    void Update()
    {
        UpdateTime();

        UpdatePowerUpsDuration();
    }

    void UpdateTime() {
        time += Time.deltaTime;

        int minutes = (int) (time / 60);
        int seconds = (int) (time - (minutes * 60));

        string min = minutes.ToString().PadLeft(2, '0');
        string sec = seconds.ToString().PadLeft(2, '0');

        timeText.text = min + ":" + sec;
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
}
