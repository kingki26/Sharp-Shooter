using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] GameObject turretBulletPrefabs;
    [SerializeField] Transform turretHead;
    [SerializeField] Transform playerTargetPoint;
    [SerializeField] Transform turretBulletSpawnPoint;
    [SerializeField] float fireRate = 2f;
    [SerializeField] int damage = 2;

    PlayerHealth player;
    void Start()
    {
        player = FindAnyObjectByType<PlayerHealth>();
        StartCoroutine(FireRountine());
    }

    void Update()
    {
        turretHead.LookAt(playerTargetPoint);
    }

    IEnumerator FireRountine()
    {
        while (player)
        {
            yield return new WaitForSeconds(fireRate);
            TurretBullet newTurretBullet = Instantiate(turretBulletPrefabs, turretBulletSpawnPoint.position, Quaternion.identity).GetComponent<TurretBullet>();
            newTurretBullet.transform.LookAt(playerTargetPoint);
            newTurretBullet.Init(damage);
        }
    }
}
