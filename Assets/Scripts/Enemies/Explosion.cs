using UnityEngine;

public class Explosion : MonoBehaviour
{
    //[SerializeField] float radius = 1.5f;
    [SerializeField] int damage = 3;
    private bool hasExploded = false;

    //void Start()
    //{
    //    Explode();
    //}

    //void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, radius);
    //}

    //void Explode()
    //{
    //    Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

    //    //foreach (Collider hitCollider in hitColliders)
    //    //{
    //    //    Debug.Log("Hit: " + hitCollider.gameObject.name);

    //    //    PlayerHealth playerHealth =
    //    //        hitCollider.GetComponentInParent<PlayerHealth>();

    //    //    if (!playerHealth)
    //    //    {
    //    //        Debug.Log("No PlayerHealth");
    //    //        continue;
    //    //    }

    //    //    Debug.Log("FOUND PLAYER HEALTH");

    //    //    playerHealth.TakeDamge(damage);
    //    //    break;
    //    //}

    //    foreach (Collider hitCollider in hitColliders)
    //    {
    //        Debug.Log("Hit: " + hitCollider.gameObject.name);

    //        PlayerHealth playerHealth =
    //            hitCollider.GetComponentInParent<PlayerHealth>();

    //        if (playerHealth)
    //        {
    //            Debug.Log("FOUND PLAYER HEALTH!");
    //            playerHealth.TakeDamge(damage);
    //        }
    //    }

    //}


    void OnTriggerEnter(Collider other)
    {
        if(hasExploded)
        {
            return;
        }

        PlayerHealth playerHealth = other.GetComponentInParent<PlayerHealth>();

        if (playerHealth != null)
        {
            hasExploded = true;
            playerHealth.TakeDamge(damage);
        }
    }
}
