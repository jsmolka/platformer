using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.IsPlayer())
            HealthManager.instance.DamagePlayer();
    }
}
