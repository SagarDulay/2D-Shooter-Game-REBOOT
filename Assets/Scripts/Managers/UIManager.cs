using System.Collections;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("GamePlay")]
    [SerializeField] private GameObject gameplayScreen;
    [SerializeField] private TextMeshProUGUI healthTextValue;
    [SerializeField] private TextMeshProUGUI scoreTextValue;
    [SerializeField] private TextMeshProUGUI highScoreTextValue;
    [SerializeField] private TextMeshProUGUI weaponTypeText;
    [SerializeField] private TextMeshProUGUI weaponTimerValue;
    [SerializeField] private TextMeshProUGUI wavePopUpText;


    [Space(10)]

    [Header("Game Over")]
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TextMeshProUGUI finalScoreValue;
    [SerializeField] private TextMeshProUGUI highScoreGameOverValue;
    private Player localPlayer;
    private GameManager localGameManager;

    [Space(10)]

    [Header("Pause Screen")]
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private TextMeshProUGUI pauseCurrentScoreValue;
    [SerializeField] private TextMeshProUGUI pauseHighScoreValue;


    void Start()
    {
        localPlayer = FindAnyObjectByType<Player>();
        localGameManager = FindAnyObjectByType<GameManager>();
    }

    void Update()
    {
        healthTextValue.text = "Health:" + localPlayer.healthModule.GetHealthPoints().ToString("F0") + "%";
        healthTextValue.color = Color.Lerp(Color.red, Color.green, localPlayer.healthModule.GetHealthPoints() / 100f);

        scoreTextValue.text = localGameManager.GetCurrentScore().ToString();
        highScoreTextValue.text = PlayerPrefs.GetInt("HighestScore").ToString();

        if (localPlayer.GetWeaponTimer() > 0f)
        {
            weaponTypeText.text = "UPGRADE: " + localPlayer.GetCurrentWeaponName();
            weaponTimerValue.text = localPlayer.GetWeaponTimer().ToString("F1") + "s";
        }

        else if (localPlayer.InvincibleOn())
        {
            weaponTypeText.text = "UPGRADE: INVINCIBLE";
            weaponTimerValue.text = localPlayer.GetInvincibilityTimer().ToString("F1") + "s";
        }


        else
        {
            weaponTypeText.text = "";
            weaponTimerValue.text = "";
        }
    }

    public void ShowGameOver()
    {
        finalScoreValue.text = "Final Score: " + localGameManager.GetCurrentScore().ToString();
        highScoreGameOverValue.text = "High Score: " + PlayerPrefs.GetInt("HighestScore").ToString();
        gameplayScreen.SetActive(false);
        gameOverScreen.SetActive(true);
    }

    public void UpdatePauseScreen()
    {
        pauseCurrentScoreValue.text = "Current Score: " + localGameManager.GetCurrentScore().ToString();
        pauseHighScoreValue.text = "High Score: " + PlayerPrefs.GetInt("HighestScore").ToString();
    }

    public void ShowWavePopUp(int waveLevel)
    {
        StartCoroutine(WavePopUpCoroutine(waveLevel));
    }

    private IEnumerator WavePopUpCoroutine(int waveLevel)
    {
        wavePopUpText.text = "Wave: " + waveLevel;
        float elapsed = 0f;

        while (elapsed < 0.5f)
        {
            elapsed += Time.deltaTime;
            wavePopUpText.color = new Color(0.2f, 1f, 0.6f, elapsed / 0.5f);
            yield return null;
        }

        yield return new WaitForSeconds(waveLevel);

        elapsed = 0f;

        while (elapsed < 0.5f)
        {
            elapsed += Time.deltaTime;
            wavePopUpText.color = new Color(0.2f, 1f, 0.6f, 1 - (elapsed / 0.5f));

        }

        wavePopUpText.color = new Color(0.2f, 1f, 0.6f, 0f);
    }

}