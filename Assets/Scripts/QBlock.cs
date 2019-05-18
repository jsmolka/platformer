using System.Collections;

using UnityEngine;

public class QBlock : MonoBehaviour
{
    public GameObject stateOn;
    public GameObject stateOff;
    public GameObject coinModel;
    public GameObject coinPickupEffect;

    private void Start()
    {
        stateOn.SetActive(true);
        stateOff.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.IsPlayer())
        {
            if (stateOff.activeInHierarchy)
                return;

            HitBlock();
            PlayerController.instance.Debounce(PlayerController.instance.transform.position.y);
        }
    }

    private void HitBlock()
    {
        stateOn.SetActive(false);
        stateOff.SetActive(true);

        StartCoroutine(CoinRoutine());
    }

    private IEnumerator CoinRoutine()
    {
        GameObject coin = Instantiate(coinModel);

        Vector3 start = transform.position;
        Vector3 end = transform.position + new Vector3(0f, 1.25f);

        float time = 0f;
        while (time <= 1f)
        {
            time += 4f * Time.deltaTime;
            coin.transform.position = Vector3.Lerp(start, end, time);
            yield return new WaitForEndOfFrame();
        }

        GameManager.instance.AddCoin();
        AudioManager.instance.PlayEffect(AudioManager.SFX.CoinPickup);

        Destroy(coin);
        Instantiate(coinPickupEffect, coin.transform.position, coin.transform.rotation);
    }
}
