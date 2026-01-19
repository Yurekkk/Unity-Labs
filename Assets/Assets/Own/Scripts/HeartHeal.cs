using UnityEngine;

public class HeartHeal : MonoBehaviour
{
    [SerializeField] public float HealAmount = 50;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other is CapsuleCollider)
        {
            Player player = other.GetComponent<Player>();
            player.Add_hp(HealAmount);
            Destroy(gameObject);
        }
    }
}
