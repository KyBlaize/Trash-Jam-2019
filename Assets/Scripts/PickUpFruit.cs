using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpFruit : MonoBehaviour
{
    public BaseFruit Fruit;
    public float RipenessTime = 1f;

    private SpriteRenderer spriteRenderer;
    private bool isFresh;

    private void Awake()
    {
        Fruit.Value = 0;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        Fruit.IsRipe = false;
        isFresh = false;
    }

    private void Update()
    {
        if (!Fruit.IsRipe)
        {
            Fruit.Ripen();
            Fruit.IsRipe = Fruit.Value < Fruit.MaxRipenessValue ? false : true;
        }
        else
        {
            if (!isFresh)
                StartCoroutine(Ripe());
            else
                Fruit.Rot();
            if (Fruit.Value < 0)
                gameObject.SetActive(false);
        }
        spriteRenderer.gameObject.transform.localScale = new Vector3(Fruit.Value/Fruit.MaxRipenessValue, Fruit.Value/Fruit.MaxRipenessValue);
    }

    private IEnumerator Ripe()
    {
        Fruit.Value = Fruit.MaxRipenessValue;
        yield return new WaitForSeconds(RipenessTime);
        isFresh = true;
    }
}
