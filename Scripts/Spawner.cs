using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float timeBetweenSpawn;
    private bool isMobile;

    [SerializeField]
    private GameObject[] asteroidsVariants;
    [SerializeField]
    private float startTimeBetweenSpawn;
    [SerializeField]
    private float decreaseTime;
    [SerializeField]
    private float minTime;
    [SerializeField]
    private float minTimeMobile;


    void Start()
    {
        timeBetweenSpawn = 2f;
        isMobile = Application.isMobilePlatform;
    }

    void Update()
    {
        if (timeBetweenSpawn <= 0)
        {
            float time;
            if (!isMobile)
            {
                time = minTime;
            }
            else 
            {
                time = minTimeMobile;
            }
            int selectAsteroidVariant = Random.Range(0, asteroidsVariants.Length);
            Instantiate(asteroidsVariants[selectAsteroidVariant], transform.position, Quaternion.identity);
            timeBetweenSpawn = startTimeBetweenSpawn;
            if (startTimeBetweenSpawn > time)
            {
                startTimeBetweenSpawn -= decreaseTime;
            }
        }
        else 
        {
            timeBetweenSpawn -= Time.deltaTime;
        }
        
    }
}
