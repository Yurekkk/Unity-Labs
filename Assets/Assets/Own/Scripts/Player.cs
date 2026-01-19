using UnityEngine;

public class Player : MonoBehaviour
{
    public uint coins = 0;
    public readonly float max_hp = 100f;
    public float hp = 100f;

    public void AddCoin()
    {
        coins++;
    }

    public void Add_hp(float delta_hp)
    {
        if (-delta_hp >= hp)
            hp = 0;
        else if (hp + delta_hp >= max_hp)
            hp = max_hp;
        else
            hp += delta_hp;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new(0, 1, 0);
    }

}
