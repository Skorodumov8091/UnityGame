using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Vector2 targetPos;
    private bool isMobile;
    private Animator animator;

    [SerializeField]
    private float shiftPos;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxHeight;
    [SerializeField]
    private float minHeight;
    [SerializeField]
    private int health;
    [SerializeField]
    private Text healthDisplay;
    [SerializeField]
    private GameObject infoPanel;
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private GameObject spawner;
    [SerializeField]
    private Text score;
    [SerializeField]
    private Text record;
    [SerializeField]
    private Text option;
    [SerializeField]
    private ScoreManager sm;

    void Start() 
    {
        gameObject.SetActive(true);
        animator = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        SwipeDetection.SwipeEvent += OnSwipe;
        isMobile = Application.isMobilePlatform;
    }

    private void OnSwipe(Vector2 direction) 
    {
        if (direction == Vector2.up && transform.position.y < maxHeight)
        {
            animator.SetTrigger("drag");
            targetPos = new Vector2(transform.position.x, transform.position.y + shiftPos);
        }
        else if (direction == Vector2.down && transform.position.y > minHeight)
        {
            animator.SetTrigger("drag");
            targetPos = new Vector2(transform.position.x, transform.position.y - shiftPos);
        }
    }

    void Update()
    {
        healthDisplay.text = ("HP: ") + health.ToString();
        if (health <= 0) 
        {
            SwipeDetection.SwipeEvent -= OnSwipe;
            if (PlayerPrefs.GetInt("Score") < sm.GetScore()) 
            {
                PlayerPrefs.SetInt("Score", sm.GetScore());
            }
            score.text = ("SCORE: ") + sm.GetScore().ToString();
            record.text = ("BEST SCORE: ") + PlayerPrefs.GetInt("Score");
            if (!isMobile)
            {
                option.text = ("\"Q\" - RESTART GAME");
            }
            else
            {
                option.text = ("TAP - RESTART GAME");
            }
            panel.SetActive(true);
            infoPanel.SetActive(false);
            spawner.SetActive(false);
            gameObject.SetActive(false);
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.W) && transform.position.y < maxHeight)
        {
            animator.SetTrigger("drag");
            targetPos = new Vector2(transform.position.x, transform.position.y + shiftPos);
        }
        else if (Input.GetKeyDown(KeyCode.S) && transform.position.y > minHeight)
        {
            animator.SetTrigger("drag");
            targetPos = new Vector2(transform.position.x, transform.position.y - shiftPos);
        }
    }

    public void Hits(int damage) 
    { 
        this.health -= damage;
    }
}
