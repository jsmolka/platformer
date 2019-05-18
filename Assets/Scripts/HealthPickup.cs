using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public GameObject pickupEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.IsPlayer())
        {
            AudioManager.instance.PlayEffect(AudioManager.SFX.HeartPickup);
            HealthManager.instance.HealPlayer();

            Destroy(gameObject);
            Instantiate(pickupEffect, transform.position, transform.rotation);
        }
    }
}
