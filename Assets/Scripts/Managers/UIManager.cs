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

    [Space(10)]

    [Header("Game Over")]
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TextMeshProUGUI finalScoreValue;
    [SerializeField] private TextMeshProUGUI highScoreGameOverValue;

    private Player localPlayer;
    private GameManager localGameManager;
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
}