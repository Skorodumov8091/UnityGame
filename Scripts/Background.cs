using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float endX;
    [SerializeField]
    private float startX;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x <= endX)
        {
            Vector2 pos = new Vector2(startX, transform.position.y);
            transform.position = pos;
        }
    }
}
