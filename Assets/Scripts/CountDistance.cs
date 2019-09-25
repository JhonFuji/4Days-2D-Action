using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDistance : MonoBehaviour
{
    public static Text distance;
    public static float time;
    private float k;
    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        distance = GetComponent<Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
        k = time * (4f + time / 5f);
        distance.text = ((int)k).ToString();
    }
}
