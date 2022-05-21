using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Static instance of Game Manager (accessible from anywhere)
    public static GameManager instance = null;

    // Player's score
    public int score = 0;
    public int highScore = 0;
    
    // Increases the score by the integer value
    public void IncreaseScore(int val)
    {
        score += val;
        if(score > highScore) { highScore = score; }
    }
    private void Awake()
    {
        if(instance == null) { instance = this; }
        else if(instance != this) { Destroy(gameObject); }

        // Don't destroy when loading a new scene
        DontDestroyOnLoad(gameObject);
    }
}
