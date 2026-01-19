using UnityEngine;

public class Player : MonoBehaviour
{
    public uint coins = 0;

    public void AddCoin()
    {
        coins++;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new(0, 1, 0);
    }

}
