using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Image blackScreen;
    public Image[] hearts;
    public Text coinText;

    public float fadeSpeed = 2f;
    public bool fadeToBlack = false;
    public bool fadeFromBlack = true;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (fadeToBlack)
        {
            blackScreen.color = new Color(
                blackScreen.color.r,
                blackScreen.color.g,
                blackScreen.color.b,
                Mathf.MoveTowards(blackScreen.color.a, 1f, fadeSpeed *  Time.deltaTime)
            );
            fadeToBlack = blackScreen.color.a != 1f;
        }

        if (fadeFromBlack)
        {
            blackScreen.color = new Color(
                blackScreen.color.r,
                blackScreen.color.g,
                blackScreen.color.b,
                Mathf.MoveTowards(blackScreen.color.a, 0f, fadeSpeed *  Time.deltaTime)
            );
            fadeFromBlack = blackScreen.color.a != 0f;
        }
    }
}
