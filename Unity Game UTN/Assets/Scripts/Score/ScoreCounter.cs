using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{

    public static int score = 0;
    public int scorePS = 50;

    private float tick = 0;
    private Text counterText;

    // Start is called before the first frame update
    void Start()
    {
        counterText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tick == 0f)
        {
            tick = Time.time + 1;
        }

        if (Time.time >= tick)
        {
            score += scorePS;
            tick = 0;
        }
        setCounterText();
    }

    void setCounterText ()
    {
        counterText.text = "Score: " + score;
    }
}
