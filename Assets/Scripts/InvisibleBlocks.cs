using System.Collections;

using UnityEngine;

public class InvisibleBlocks : MonoBehaviour
{
    public GameObject[] blocks;

    private void Start()
    {
        SetBlocksVisible(false);
    }

    public void ShowPath()
    {
        StartCoroutine(ShowPathRoutine());
    }

    private IEnumerator ShowPathRoutine()
    {
        for (int i = 0; i < blocks.Length; ++i)
        {
            SetBlockVisible(i, true);

            float time = 0f;
            while (time <= 0.2f)
            {
                time += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }

            SetBlockVisible(i, false);
        }
        FindObjectOfType<InvisibleButtonController>().SetPressed(false);
    }

    private void SetBlocksVisible(bool visible)
    {
        for (int i = 0; i < blocks.Length; ++i)
            SetBlockVisible(i, visible);
    }

    private void SetBlockVisible(int index, bool visible)
    {
        blocks[index].GetComponent<MeshRenderer>().enabled = visible;
    }
}
