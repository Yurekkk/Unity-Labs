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

    void Update()
    {
        // Проверяем, есть ли игрок рядом
        Collider[] hits = Physics.OverlapSphere(transform.position, explosionRadius, playerLayer);
        foreach (var hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                Player player = hit.GetComponent<Player>();
                player.Add_hp(-damage);
                Detonate();
                return;
            }
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
            transform.position += transform.forward * speed * Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator DetonateAfterDelay()
    {
        yield return new WaitForSeconds(detonationTime);
        Detonate();
    }
}
