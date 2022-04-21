using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private bool isMobile;

    [SerializeField]
    private Text healthDisplay;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private GameObject gamePanel;
    [SerializeField]
    private GameObject resultPanel;
    [SerializeField]
    private Text score;
    [SerializeField]
    private Text record;
    [SerializeField]
    private Text option;
    [SerializeField]
    private ScoreManager sm;
    [SerializeField]
    private Player player;
    [SerializeField]
    private GameObject spawner;

    void Start()
    {
        isMobile = Application.isMobilePlatform;

    }

    void Update()
    {
        scoreText.text = ("SCORE: ") + sm.GetScore().ToString();
        int health = player.GetHealth();
        healthDisplay.text = ("HP: ") + health.ToString();
        if (health <= 0) 
        {
            if (PlayerPrefs.GetInt("Score") < sm.GetScore())
            {
                PlayerPrefs.SetInt("Score", sm.GetScore());
            }
            option.text = isMobile ? "TAP - RESTART GAME" : "\"Q\" - RESTART GAME";
            score.text = ("SCORE: ") + sm.GetScore().ToString();
            record.text = ("BEST SCORE: ") + PlayerPrefs.GetInt("Score");
            spawner.SetActive(false);
            gamePanel.SetActive(false);
            resultPanel.SetActive(true);
        }
    }
}
