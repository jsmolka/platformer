using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;

    public int health;
    public int maxHealth = 3;

    public float invincibleDuration = 2f;
    private float invincibleTimer;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ResetHealth();
    }

    private void Update()
    {
        if (invincibleTimer > 0)
        {
            invincibleTimer -= Time.deltaTime;

            bool visible = Mathf.Floor(invincibleTimer * 5f) % 2 == 0 || invincibleTimer <= 0;

            foreach (GameObject part in PlayerController.instance.modelParts)
                part.SetActive(visible);
        }
    }

    public void DamagePlayer()
    {
        if (invincibleTimer > 0)
            return;

        health--;

        if (health == 0)
        {
            ResetHealth();
            GameManager.instance.Respawn();
        }
        else
        {
            PlayerController.instance.Knockback();
            invincibleTimer = invincibleDuration;
        }

        AudioManager.instance.PlayEffect(AudioManager.SFX.TakeDamage);

        UpdateUI();
    }

    public void ResetHealth()
    {
        health = maxHealth;

        UpdateUI();
    }

    public void HealPlayer()
    {
        health = Mathf.Min(health + 1, maxHealth);

        UpdateUI();
    }

    public void UpdateUI()
    {
        for (int i = 0; i < UIManager.instance.hearts.Length; ++i)
            UIManager.instance.hearts[i].enabled = i < health;
    }
}
