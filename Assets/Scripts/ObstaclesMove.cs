using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesMove : MonoBehaviour
{
    public float X;
    public float Y;
    // Start is called before the first frame update
    void Start()
    {
    }
    private void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x +X, transform.position.y+Y);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
