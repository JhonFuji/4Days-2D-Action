using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public float generateX;
    public float yMax;
    public float yMin;
    public int obstacleCountMax;
    public float generateProbability;
    public int sectionCount;
    public float generateSpan;
    private float lastGeneratedTrial=0;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        float current = Time.fixedTime;
        //Debug.Log(current);
        //Debug.Log(lastGeneratedTrial);
        if (current -lastGeneratedTrial < generateSpan) {
            return;
        }
        lastGeneratedTrial = current;
        Enumerable.Range(0, sectionCount)
            .Select(i => i < obstacleCountMax && UnityEngine.Random.Range(0.0f, 1.0f) <= generateProbability)
            .OrderBy(i => Guid.NewGuid())
            .Select((shouldGenerate, index) => new { shouldGenerate, index }).ToList()
            .ForEach(it =>
            {
                //Debug.Log(it.shouldGenerate);
                if (it.shouldGenerate)
                {
                    int obstacleIndex = UnityEngine.Random.Range(0, obstaclePrefabs.Length);
                    GameObject o = Instantiate(obstaclePrefabs[obstacleIndex]);
                    var Y = ((sectionCount - 1 - it.index) * yMin + it.index * yMax) / (sectionCount - 1);
                    o.GetComponent<Obstacle>().Init(generateX, Y);
                }
            });
    }
}
