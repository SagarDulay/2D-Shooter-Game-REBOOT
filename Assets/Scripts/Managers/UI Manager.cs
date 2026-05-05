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
        scoreTextValue.text = localGameManager.GetCurrentScore().ToString();

        highScoreTextValue.text = PlayerPrefs.GetInt("HighestScore").ToString();

        healthTextValue.color = Color.Lerp(Color.red, Color.green, localPlayer.healthModule.GetHealthPoints() / 100f);

        weaponTypeText.text = "Upgrade: " + localPlayer.GetCurrentWeaponName();

        if (localPlayer.GetWeaponTimer() > 0f)
        {
            weaponTimerValue.text = localPlayer.GetWeaponTimer().ToString("F1") + "s";
        }
        else
        {
            weaponTimerValue.text = "";
        }
    }

    public void ShowGameOver()
    {
        gameplayScreen.SetActive(false);
        gameOverScreen.SetActive(true);
    }
}
