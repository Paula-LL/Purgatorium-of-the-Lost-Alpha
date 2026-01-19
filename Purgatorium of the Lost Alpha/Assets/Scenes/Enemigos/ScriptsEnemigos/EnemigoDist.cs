using UnityEngine;

public class EnemigoDis : MonoBehaviour
{
    [Header("Follow Settings")]
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float stopDistance = 5f;

    [Header("Shooting Settings")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float shootCooldown = 2f;

    private Transform player;
    private float nextShootTime;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag(playerTag);
        if (playerObj != null)
            player = playerObj.transform;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        // Mirar al player
        Vector3 dir = player.position - transform.position;
        dir.y = 0;
        transform.forward = dir.normalized;

        // Movimiento
        if (distance > stopDistance)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }

        // Disparo (solo spawnea)
        if (distance <= stopDistance && Time.time >= nextShootTime)
        {
            SpawnProjectile();
            nextShootTime = Time.time + shootCooldown;
        }
    }

    void SpawnProjectile()
    {
        if (projectilePrefab == null || shootPoint == null) return;

        Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
    }
}
