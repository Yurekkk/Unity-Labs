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
        if (coinText) coinText.text = "$: " + 0;
        if (HPSlider) HPSlider.value = 1f;
    }

    void Update()
    {
        float hp = player.hp;
        float maxHp = player.max_hp;

        if (coinText) coinText.text = "$: " + player.coins;
        if (HPSlider) HPSlider.value = hp / maxHp;
        if (HPTextInside) HPTextInside.text = $"{hp}/{maxHp}";
    }
}