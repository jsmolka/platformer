using System.Collections;

using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject deathEffect;

    private Vector3 spawn;
    private int coins;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        UIManager.instance.coinText.text = coins.ToString();

        StartCoroutine(StartRoutine());
    }

    private IEnumerator StartRoutine()
    {
        yield return new WaitForSeconds(1);

        PlayerController.instance.enabled = false;

        AudioManager.instance.PlayEffect(AudioManager.SFX.Pipe);

        Vector3 start = PlayerController.instance.transform.position;
        Vector3 end = PlayerController.instance.transform.position + new Vector3(0f, 1.5f);

        float time = 0f;
        while (time <= 1f)
        {
            time += Time.deltaTime;
            PlayerController.instance.transform.position = Vector3.Lerp(start, end, time);
            yield return new WaitForEndOfFrame();
        }

        spawn = PlayerController.instance.transform.position;

        PlayerController.instance.enabled = true;
        CameraController.instance.brain.enabled = true;
    }

    public void Respawn()
    {
        foreach (var platform in FindObjectsOfType<Platform>())
            platform.playerOnPlatform = false;

        StartCoroutine(RespawnRoutine());
    }

    public IEnumerator RespawnRoutine()
    {
        PlayerController.instance.gameObject.SetActive(false);
        CameraController.instance.brain.enabled = false;

        Instantiate(deathEffect, PlayerController.instance.transform.position, PlayerController.instance.transform.rotation);

        UIManager.instance.fadeToBlack = true;
        yield return new WaitForSeconds(2f);
        UIManager.instance.fadeFromBlack = true;

        HealthManager.instance.ResetHealth();

        PlayerController.instance.isKnockedBack = false;
        PlayerController.instance.gameObject.transform.position = spawn;
        PlayerController.instance.gameObject.SetActive(true);
        CameraController.instance.brain.enabled = true;
    }

    public void SetSpawn(Vector3 position)
    {
        spawn = position;
    }

    public void AddCoin()
    {
        coins++;

        UIManager.instance.coinText.text = coins.ToString();
    }
}
