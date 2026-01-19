using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Player player;
    public TMP_Text coinText;
    public Slider HPSlider;
    public TMP_Text HPTextInside;

    void Start()
    {
        HPSlider.value = 1f;
        coinText.text = "$: " + 0;
    }

    void Update()
    {
        float hp = player.hp;
        float maxHp = player.max_hp;

        coinText.text = "$: " + player.coins;
        HPSlider.value = hp / maxHp;
        HPTextInside.text = $"{hp}/{maxHp}";
    }
}