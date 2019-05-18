using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.IsEnemy())
            other.GetComponent<EnemyHealthManager>().DamageEnemy();
    }
}
