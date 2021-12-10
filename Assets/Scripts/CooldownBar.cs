using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownBar : MonoBehaviour
{
    float maxValue = 3f;
    public float time;
    float prosent = 1;

    private void Update()
    {
        transform.localScale = new Vector2(transform.localScale.x, maxValue);

        maxValue = Mathf.Lerp(1, 0, prosent);
        prosent -= Time.deltaTime / time;
        if (prosent <= 0)
        {
            Destroy(transform.parent.gameObject);
            Destroy(this.gameObject);
        }
    }
}
