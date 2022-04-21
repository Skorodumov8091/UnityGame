using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Vector2 targetPos;
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

    void Start() 
    {
        gameObject.SetActive(true);
        animator = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        SwipeDetection.SwipeEvent += OnSwipe;
    }

    void Update()
    {
        if (health <= 0) 
        {
            SwipeDetection.SwipeEvent -= OnSwipe;
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

    public void Hits(int damage) 
    { 
        this.health -= damage;
    }
    public int GetHealth()
    {
        return this.health;
    }
}
