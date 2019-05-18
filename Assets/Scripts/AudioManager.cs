using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource music;
    public AudioSource[] sfx;

    public enum SFX
    {
        Checkpoint  = 0,
        TakeDamage  = 1,
        CoinPickup  = 2,
        EnemyDeath  = 3,
        HeartPickup = 4,
        Jump        = 5,
        Pipe        = 6,
        BillBlaster = 7,
        ButtonClick = 8
    };

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        music.Play();
    }

    public void PlayEffect(SFX sfx)
    {
        GetEffect(sfx).Play();
    }

    public void PlayEffect(SFX sfx, Vector3 position)
    {
        AudioSource audio = GetEffect(sfx);
        audio.transform.position = position;
        audio.Play();
    }

    private AudioSource GetEffect(SFX sfx)
    {
        return this.sfx[(int)sfx];
    }
}
