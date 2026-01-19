using UnityEngine;
using System.Collections;

public class PoisonEffect : MonoBehaviour
{
    public float damage = 5f;
    public float poisonDamagePerSecond = 1f;
    public float poisonDuration = 3f;
    public GameObject poisonIcon;
    public GameObject player;
    private Coroutine activePoison;

    void Start()
    {
        poisonIcon.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other is CapsuleCollider)
        {
            player.GetComponent<Player>().Add_hp(-damage);
            if (activePoison != null)
                StopCoroutine(activePoison);
            activePoison = StartCoroutine(PoisonRoutine());
        }
    }

    IEnumerator PoisonRoutine()
    {
        poisonIcon.SetActive(true);

        float elapsed = 0f;
        while (elapsed < poisonDuration)
        {
            yield return new WaitForSeconds(1f);
            player.GetComponent<Player>().Add_hp(-poisonDamagePerSecond);
            elapsed += 1f;
        }

        poisonIcon.SetActive(false);
        activePoison = null;
    }
}