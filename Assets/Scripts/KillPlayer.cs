using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.IsPlayer())
        {
            AudioManager.instance.PlayEffect(AudioManager.SFX.TakeDamage);
            GameManager.instance.Respawn();
        }
    }
}
