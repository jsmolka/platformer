using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public GameObject pickupEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.IsPlayer())
        {
            AudioManager.instance.PlayEffect(AudioManager.SFX.CoinPickup);
            GameManager.instance.AddCoin();

            Destroy(gameObject);
            Instantiate(pickupEffect, transform.position, transform.rotation);
        }
    }
}
