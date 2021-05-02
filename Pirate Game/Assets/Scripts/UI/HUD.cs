using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TextCore;
using TMPro;

public class HUD : MonoBehaviour
{
    [Header("References")]
    public Player_Mov Player;
    public Text Timertext;
    public Player_Mov player;
    public GameManager scoreManager;
    public TextMeshProUGUI scoreText;
    public OptionsInformation info;

    void OnEnable()
    {
        scoreManager.score = 0;
    }
    void Start()
    {
        Timertext.text = "Time Left:" + info.gameTime.ToString("F") + "seconds";
    }
    void Update()
    {
        if(info.gameTime > 0)  
            Timertext.text = "Time Left:" + info.gameTime.ToString("F") + "seconds";
        else
            Timertext.text = "Your time is over";
        if(player.currentHealth > 0)
            scoreText.text = $"{scoreManager.score}";
        else
            scoreText.text = "Your score is: " + scoreManager.score;
    }
}
