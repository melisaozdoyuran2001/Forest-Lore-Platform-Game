using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public float speed = 2.0f; 
    public float distance = 2.0f; 

    private bool movingRight = true;
    private Vector3 startPos;

   
    void Start()
    {
        startPos = transform.position;
        StartCoroutine(MoveLeftAndRight());
    }

    IEnumerator MoveLeftAndRight()
    {
        while (true)
        {
           
            Vector3 endPos = startPos + (movingRight ? Vector3.right * distance : Vector3.left * distance);

            transform.localScale = new Vector3(movingRight ? 2.5f : -2.5f, 2.5f, 1f);

            while ((movingRight ? transform.position.x < endPos.x : transform.position.x > endPos.x))
            {
               
                transform.position += (movingRight ? Vector3.right : Vector3.left) * speed * Time.deltaTime;
                yield return null;
            }

            // Switch direction
            movingRight = !movingRight;

            // Wait a frame and continue
            yield return null;
        }
    }
}
