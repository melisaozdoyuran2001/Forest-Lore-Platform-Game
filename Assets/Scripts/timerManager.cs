using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
public class timerManager : MonoBehaviour
{
    public float timeLeft = 60.0f; 
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI youLost;
    
     private void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            UpdateTimerText();
            if (timeLeft <= 10) {
                timerText.GetComponent<CanvasRenderer>().SetColor(Color.red);
            }
            if (timeLeft <= 0)
            {
                PlayerLost();
            }
        }
    }

    private void UpdateTimerText()
    {
        timerText.text = "Time Left: " + Mathf.Ceil(timeLeft).ToString();
    }

    private void PlayerLost()
    {
      youLost.gameObject.SetActive(true);
      Time.timeScale = 0f; 
    }
}
