using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public Player player;
    public TMP_Text coinText;

    void Start()
    {
        coinText.text = "$: " + 0;
    }

    void Update()
    {
        coinText.text = "$: " + player.coins;
    }
}