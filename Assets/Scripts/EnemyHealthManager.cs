using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int maxHealth = 1;
    private int health;

    public GameObject deathEffect;

    private void Start()
    {
        health = maxHealth;
    }

    public void DamageEnemy()
    {
        health--;

        if (health <= 0)
        {
            PlayerController.instance.Bounce();
            AudioManager.instance.PlayEffect(AudioManager.SFX.EnemyDeath);

            Destroy(gameObject);
            Instantiate(deathEffect, transform.position + new Vector3(0f, 1.2f, 0f), transform.rotation);
        }
    }
}
