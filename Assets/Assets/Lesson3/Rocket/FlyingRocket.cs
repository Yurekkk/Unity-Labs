using System.Collections;
using UnityEngine;

public class FlyingRocket : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float detonationTime;
    [SerializeField] float explosionRadius;
    [SerializeField] float damage;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] GameObject explosion;

    void Awake()
    {
        StartCoroutine(Move());
        StartCoroutine(DetonateAfterDelay());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other is CapsuleCollider)
        {
            Player player = other.GetComponent<Player>();
            player.Damage(damage);
            Detonate();
            return;
        }
    }

    void Detonate()
    {
        Debug.Log("Detonated");
        Destroy(Instantiate(explosion, transform.position, transform.rotation), explosion.GetComponent<ParticleSystem>().main.duration);
        Destroy(gameObject);
    }

    IEnumerator Move()
    {
        while (true)
        {
            transform.position += speed * Time.fixedDeltaTime * transform.forward;
            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator DetonateAfterDelay()
    {
        yield return new WaitForSeconds(detonationTime);
        Detonate();
    }
}
