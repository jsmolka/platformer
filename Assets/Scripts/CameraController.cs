using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    public CinemachineBrain brain;

    private void Awake()
    {
        instance = this;
    }
}
