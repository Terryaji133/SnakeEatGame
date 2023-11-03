using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreUI : MonoBehaviour
{
    public TMP_Text scoreText;
    int score;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ReastScore()
    {
        score = 0;
        scoreText.text= score.ToString();
    }
    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
    public int GetScore()
    {
        return score;
    }

}