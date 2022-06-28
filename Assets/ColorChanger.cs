using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] float latency = 0.2f;
    GridLayoutGroup grid;
    [SerializeField] List<SpriteRenderer> blocks;
    [SerializeField] int blockCount;
    [SerializeField] Color[] colors;
    [SerializeField] int colorCount;
    int maxColorIndex;

    // Start is called before the first frame update
    void Start()
    {
        grid = GetComponent<GridLayoutGroup>();
        foreach(Block gO in FindObjectsOfType<Block>())
        {
            blocks.Add(gO.GetComponent<SpriteRenderer>());
        }
        blockCount = 0;
        colorCount = 0;
        StartCoroutine(nameof(ColorBlocks));
    }

    IEnumerator ColorBlocks()
    {
        blocks[blockCount].color = colors[colorCount];
        if (++blockCount >= blocks.Count)
        {
            blockCount = 0;
            colorCount = colorCount >= colors.Length - 1 ? 0 : colorCount + 1;
        }
        yield return new WaitForSeconds(latency);

        StartCoroutine(nameof(ColorBlocks));
    }

}
