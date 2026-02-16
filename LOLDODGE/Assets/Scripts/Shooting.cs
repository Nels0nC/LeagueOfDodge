using UnityEngine;

public class Shooting : MonoBehaviour
{

    public GameObject projectilePrefab;
    public float fireRate = 2f;

    private float nextFireTime;
    private Transform player;
    public float spawnOffset = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
    if (player == null) return;

    Vector2 direction = ((Vector2)player.position - (Vector2)transform.position).normalized;
    Vector2 spawnPos = (Vector2)transform.position + direction * spawnOffset;

    GameObject proj = Instantiate(projectilePrefab, spawnPos, Quaternion.identity);
    proj.GetComponent<Projectile>().SetDirection(direction);
    }
}
