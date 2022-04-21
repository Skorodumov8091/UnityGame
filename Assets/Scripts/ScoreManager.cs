using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    private int score;

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
