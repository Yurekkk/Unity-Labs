using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Player : MonoBehaviour
{
    public uint coins = 0;
    public readonly float max_hp = 100f;
    public float hp = 100f;
    public bool dead = false;

    public GameObject deathScreen;
    public float deathScreenFadeDuration = 1f;

    public void AddCoin()
    {
        coins++;
    }

    public void Damage(float damage)
    {
        Add_hp(-damage);
    }

    public void Add_hp(float delta_hp)
    {
        if (-delta_hp >= hp)
        {
            hp = 0;
            Die();
        }
        else if (hp + delta_hp >= max_hp)
            hp = max_hp;
        else
            hp += delta_hp;
    }

    void Die()
    {
        dead = true;
        Time.timeScale = 0f; // Останавливаем игру
        StartCoroutine(DeathScreenFadeIn());
    }

    IEnumerator DeathScreenFadeIn()
    {
        // Плавное появление для экрана смерти
        float elapsed = 0f;
        while (elapsed < deathScreenFadeDuration)
        {
            deathScreen.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(0f, 1f, elapsed / deathScreenFadeDuration);
            elapsed += Time.unscaledDeltaTime; // работает при timeScale = 0
            yield return null;
        }
        deathScreen.GetComponent<CanvasGroup>().alpha = 1f;
    }
}
