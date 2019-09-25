using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Plane : MonoBehaviour
{
    public float V;
    public float F;
    public float A;
    public static float t = 0;
    public GameObject kmObj;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void FixedUpdate()
    {
        float time = CountDistance.time/30f;
        if (Input.GetKey(KeyCode.Space))
        {
            V += F*(1+time);
        }
        else
        {
            V -= A * (1 + time);
        }
        //Debug.Log(V);
        transform.position = new Vector2(transform.position.x, transform.position.y + V);
    }
    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("save "+Application.persistentDataPath);
        File.WriteAllText(Path.Combine(Application.persistentDataPath, "Newdeta.txt"),  kmObj.GetComponent<Text>().text);
//        new StreamWriter(Application.persistentDataPath + "ScoreDeta.txt",true).WriteLine(kmObj.GetComponent<Text>().text);
        File.AppendAllText(Path.Combine(Application.persistentDataPath, "ScoreDeta.txt"), kmObj.GetComponent<Text>().text+"\n");
        //win(実行ファイル名_data)フォルダ
        //debug(プロジェクトフォルダ)/Assets
        SceneManager.LoadScene("ScoreScene");
    }
}
