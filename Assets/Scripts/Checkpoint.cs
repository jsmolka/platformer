using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject checkpointOn;
    public GameObject checkpointOff;

    private void OnTriggerEnter(Collider other)
    {
        if (other.IsPlayer())
        {
            if (!checkpointOn.activeInHierarchy)
                AudioManager.instance.PlayEffect(AudioManager.SFX.Checkpoint);

            GameManager.instance.SetSpawn(transform.position);

            foreach (var checkpoint in FindObjectsOfType<Checkpoint>())
                checkpoint.SetEnabled(false);

            SetEnabled(true);
        }
    }

    public void SetEnabled(bool enabled)
    {
        checkpointOn.SetActive(enabled);
        checkpointOff.SetActive(!enabled);
    }
}
