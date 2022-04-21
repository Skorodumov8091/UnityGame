using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Animator animator;
    private bool isMobile;

    [SerializeField]
    private int damage;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float mobileSpeed;
    [SerializeField]
    private GameObject eff;
    [SerializeField]
    private GameObject sound;
    void Start()
    {
        animator = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        isMobile = Application.isMobilePlatform;
    }
    void Update()
    {
        if (!isMobile)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * mobileSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            animator.SetTrigger("drag");
            Instantiate(sound, transform.position, Quaternion.identity);
            Instantiate(eff, transform.position, Quaternion.identity);
            other.GetComponent<Player>().Hits(damage);
            Destroy(gameObject);
        }
    }
}
