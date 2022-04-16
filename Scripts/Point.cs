using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField]
    private GameObject[] asteroids;

    void Start()
    {
        int selectAsteroid = Random.Range(0, asteroids.Length);
        Instantiate(asteroids[selectAsteroid], transform.position, Quaternion.identity);
    }
}
