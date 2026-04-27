using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthTextValue;
    [SerializeField] private TextMeshProUGUI scoreTextValue;

    private Player localPlayer;
    private GameManager localGameManager;
    void Start()
    {
        localPlayer = FindAnyObjectByType<Player>();
        localGameManager = FindAnyObjectByType<GameManager>();
    }

    void Update()
    {
        healthTextValue.text = "Health:" + localPlayer.healthModule.GetHealthPoints().ToString() + "%"; 
        scoreTextValue.text = localGameManager.GetCurrentScore().ToString();
    }
}
