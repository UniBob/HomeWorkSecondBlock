using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScripts : MonoBehaviour
{
    public int score;
    public bool lifeUpdater;

    float y = 11;
    float minX = -6;
    float maxX = 6;
    float z = 0;

    GameLogic gl;
    Rigidbody2D rb;

    private void Awake()
    {
        gl = FindObjectOfType<GameLogic>();
        rb = GetComponent<Rigidbody2D>();        
    }

    private void Start()
    {
        transform.position = new Vector3(Random.Range(minX, maxX), y, z);
        rb.velocity += new Vector2(Random.Range(minX-5, maxX+5), -13.9f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            if (score >= 0) gl.LifeUpdate(-1);
            Destroy(gameObject);
        }
        else
            if(collision.gameObject.CompareTag("platform"))
            {
                if (lifeUpdater) gl.LifeUpdate(1);
                gl.ScoreUpdate(score);
                Destroy(gameObject);
            }
    }
}
