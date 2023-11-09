using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class bombController : MonoBehaviour
{
    private float scoreInt = 0;
    public TextMeshProUGUI ScoreText ;
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ground") || 
        other.gameObject.CompareTag("DeadZone")) 
            Destroy(gameObject); 
        if(other.gameObject.CompareTag("Enemy")) {
            Destroy(other.gameObject);
            Destroy(gameObject); 
            scoreInt += 10 ;
            ScoreManager.Instance.IncreaseScore() ; 
        }

    }
}

