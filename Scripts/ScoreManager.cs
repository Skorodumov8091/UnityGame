using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    private int score;
    [SerializeField]
    private Text scoreText;

    void Update()
    {
        scoreText.text = ("SCORE: ") + score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Asteroid"))
        {
            score++;
        }
    }

    public int GetScore() 
    { 
        return score;
    }

    
}
