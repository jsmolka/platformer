using System.Collections;

using UnityEngine;

public class ExitLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.IsPlayer())
            StartCoroutine(ExitRoutine());
    }

    private IEnumerator ExitRoutine()
    {
        PlayerController.instance.animator.SetFloat("Speed", 0f);
        PlayerController.instance.enabled = false;

        UIManager.instance.fadeToBlack = true;
        AudioManager.instance.PlayEffect(AudioManager.SFX.Pipe);

        Vector3 start = PlayerController.instance.transform.position;
        Vector3 end = PlayerController.instance.transform.position + new Vector3(0f, -1.5f);

        float time = 0f;
        while (time <= 1f)
        {
            time += Time.deltaTime;
            PlayerController.instance.transform.position = Vector3.Lerp(start, end, time);
            yield return new WaitForEndOfFrame();
        }

        Application.Quit();
    }
}
