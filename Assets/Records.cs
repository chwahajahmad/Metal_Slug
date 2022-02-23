using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Records : MonoBehaviour
{

    public float Score;
    public int Health;
    public Text ScoreTxt;
    public Text HealthTxt;
    // Start is called before the first frame update
    void Start()
    {
        Score = 0f;   
        Health = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if(Health<=0)
            SceneManager.LoadScene(0);

        ScoreTxt.text = "Score: " + (int)Score;
        HealthTxt.text = "Health: " + Health;
    }
}
