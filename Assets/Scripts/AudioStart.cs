using UnityEngine;

public class AudioStart : MonoBehaviour
{
    public float start;

    private void Start()
    {
        GetComponent<AudioSource>().time = GetComponent<AudioSource>().clip.length * start;
    }
}
