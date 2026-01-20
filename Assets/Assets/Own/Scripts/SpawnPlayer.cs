using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public Player player;
    public Vector3 position;
    void Start()
    {
        player.transform.position = position;
    }
}
