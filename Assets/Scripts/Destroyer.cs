using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField]
    private float lifeTime;
    void Start()
    {
        Destroy(gameObject, lifeTime);   
    }
}
