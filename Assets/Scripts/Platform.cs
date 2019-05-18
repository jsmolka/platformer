using UnityEngine;

public class Platform : MonoBehaviour
{
    public Vector3 start;
    public Vector3 end;
    public float timeToReach = 5f;
    public bool playerOnPlatform = false;

    private float time;
    private Vector3 previous;

    private void Start()
    {
        transform.position = start;
        previous = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.IsPlayer())
            playerOnPlatform = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.IsPlayer())
            playerOnPlatform = false;
    }

    private void Update()
    {
        time += Time.deltaTime / timeToReach;
        transform.position = Vector3.Lerp(start, end, time);

        if (playerOnPlatform)
            PlayerController.instance.character.Move(transform.position - previous);
        previous = transform.position;

        if (transform.position == end)
            SwitchPositions();
    }

    private void SwitchPositions()
    {
        var temp = start;
        start = end;
        end = temp;
        time = 0;
    }
}
