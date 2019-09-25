using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky : MonoBehaviour
{
    public float v;
    public GameObject[] skytex;
    //private float[] z = new float[] { -0.1f, 0.0f, 0.1f };
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        for (int i = 0; i < 2; i++)
        {
            skytex[i].transform.position
                = new Vector3(skytex[i].transform.position.x + v * (1 + CountDistance.time / 30f), skytex[i].transform.position.y, skytex[i].transform.position.z-0.001f);
            if (skytex[i].transform.position.x < -18f)
            {
                skytex[i].transform.position
                    = new Vector3(skytex[i].transform.position.x + 36f, skytex[i].transform.position.y, 5f);
            }
        }
    }
}
