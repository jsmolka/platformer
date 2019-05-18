using UnityEngine;

public class InvisibleButtonController : MonoBehaviour
{
    public GameObject knobOn;
    public GameObject knobOff;

    private void Start()
    {
        SetPressed(false);        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.IsPlayer())
        {
            if (!IsPressed())
            {
                SetPressed(true);
                AudioManager.instance.PlayEffect(AudioManager.SFX.ButtonClick);
                FindObjectOfType<InvisibleBlocks>().ShowPath();
            }
        }
    }

    public void SetPressed(bool pressed)
    {
        knobOn.SetActive(!pressed);
        knobOff.SetActive(pressed);
    }

    public bool IsPressed()
    {
        return knobOff.activeInHierarchy;
    }
}
