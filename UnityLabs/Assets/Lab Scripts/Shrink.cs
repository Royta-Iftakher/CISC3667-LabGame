using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrink : MonoBehaviour
{
    [SerializeField] public float timer = 0f;
    [SerializeField] public float growTime = 6f;
    [SerializeField] public float maxSize = 2f;
    [SerializeField] public bool isMaxSize = false;
    [SerializeField] public int skillScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (isMaxSize == false)
        {
            StartCoroutine(ShrinkSpider());
        }
    }

    void Update()
    {
        if (!isMaxSize)
        {
            skillScore++;
        }
    }

    private IEnumerator ShrinkSpider()
    {
        Vector2 startScale = transform.localScale;
        Vector2 minScale = new Vector2(maxSize, maxSize);

        do
        {
            transform.localScale = Vector3.Lerp(startScale, minScale, timer / growTime);
            timer += Time.deltaTime;
            yield return null;

        }
        while (timer < growTime);

        isMaxSize = true;
    }
}
