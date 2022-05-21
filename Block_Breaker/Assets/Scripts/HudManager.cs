using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{

    public Text scoreLabel;
    public Text highScoreLabel;
    // Start is called before the first frame update
    void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        if (GameManager.instance != null)
        {
            scoreLabel.text = "Score: " + GameManager.instance.score;
            highScoreLabel.text = "High Score: " + GameManager.instance.highScore;
        }
    }
}
