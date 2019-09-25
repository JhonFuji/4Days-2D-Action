using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    public GameObject backline;
    public GameObject p;
    public bool t = true;
    public float v;
    // Start is called before the first frame update
    void Start()
    {
        p.transform.position = new Vector2(-15f, 6f);
    }
    private void FixedUpdate()
    {
        p.transform.position = new Vector2(p.transform.position.x + v, p.transform.position.x * p.transform.position.x / 45f + 1f); //*4f/ 225f);
        if (p.transform.position.x > 15f) { p.transform.position = new Vector2(-15f, 6f); }
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(t);
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneChenge();
        }
        else if (Input.anyKeyDown )
        {
            if (t) { t = false; }
            else { t = true; }
        }
        if (t) { backline.transform.position = new Vector2(-4.5f, backline.transform.position.y); }
        else { backline.transform.position = new Vector2(4.5f, backline.transform.position.y); }
    }
    void SceneChenge()
    {
        if (t) { SceneManager.LoadScene("GameScene"); }
        else { SceneManager.LoadScene("ScoreScene"); }
    }
}
