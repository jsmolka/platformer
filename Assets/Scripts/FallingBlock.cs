using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    public GameObject block;
    public float fallDistance;
    public float fallPower = 6;
    public float idleDuration = 1;
    public float resetDuration = 2;

    private Vector3 start;
    private Vector3 end;

    private enum State
    {
        Fall,
        Reset,
        Idle
    };
    private State state = State.Idle;
    private float time = 0;

    private void Start()
    {
        start = block.transform.position;
        end = block.transform.position - new Vector3(0f, fallDistance);
    }

    private void Update()
    {
        switch (state)
        {
            case State.Fall:
                time += Time.deltaTime;
                block.transform.position = Vector3.Lerp(start, end, Mathf.Pow(time, fallPower));
                if (block.transform.position == end)
                {
                    state = State.Reset;
                    time = 0;
                }
                break;

            case State.Reset:
                time += Time.deltaTime / resetDuration;
                block.transform.position = Vector3.Lerp(end, start, time);
                if (block.transform.position == start)
                {
                    state = State.Idle;
                    time = 0;
                }
                break;

            case State.Idle:
                time += Time.deltaTime;
                if (time >= idleDuration)
                {
                    state = State.Fall;
                    time = 0;
                }
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.IsPlayer())
            HealthManager.instance.DamagePlayer();
    }
}
