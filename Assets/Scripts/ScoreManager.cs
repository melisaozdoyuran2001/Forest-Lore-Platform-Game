using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int scoreInt = 0;
    public TextMeshProUGUI Score;
    public AudioClip scoreSound;
    private AudioSource audioSource;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    public void IncreaseScore()
    {
        scoreInt += 10;
        Score.text = "Score: " + scoreInt.ToString();
        audioSource.PlayOneShot(scoreSound);
    }
}

    