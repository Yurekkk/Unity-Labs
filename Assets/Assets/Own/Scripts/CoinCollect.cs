using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            player.AddCoin();
            Destroy(gameObject);
        }
    }
}
