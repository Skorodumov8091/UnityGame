using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float timeBetweenSpawn;
    private float currentTime;
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
        currentTime = isMobile ? minTimeMobile : minTime;
    }

    void Update()
    {
        if (timeBetweenSpawn <= 0)
        {
            int selectAsteroidVariant = Random.Range(0, asteroidsVariants.Length);
            Instantiate(asteroidsVariants[selectAsteroidVariant], transform.position, Quaternion.identity);
            timeBetweenSpawn = startTimeBetweenSpawn;
            if (startTimeBetweenSpawn > currentTime) 
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
