using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    public int num;
    public GameObject Numbers;
    public GameObject Scores;
    public GameObject KmScale;
    public GameObject NewDeta;
    public GameObject Title;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("read " + Application.persistentDataPath);
        Text ScTxt = Scores.GetComponent<Text>();
        File.ReadAllLines(Path.Combine(Application.persistentDataPath, "ScoreDeta.txt")).ToList()
            .Select((item) => int.Parse(item))
            .Distinct().OrderByDescending((a) => a).ToList()
            .Take(10).ToList()
            .ForEach((a) => ScTxt.text += a + "\n");

        //Text NuTxt = Numbers.GetComponent<Text>();
        //Text kmTxt = kmScale.GetComponent<Text>();

        string n="";
        string k="";
        for(int i=1;i< 11; i++)
        {
            n += i + ".\n";
            k += "km\n";
        }
        Numbers.GetComponent<Text>().text = n;
        KmScale.GetComponent<Text>().text = k;
        NewDeta.GetComponent<Text>().text = File.ReadAllText(Path.Combine(Application.persistentDataPath, "Newdeta.txt"));


        //File.WriteAllLines("Assets/Scripts/ScoreDeta.txt", allTextSt);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
