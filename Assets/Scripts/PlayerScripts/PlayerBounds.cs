using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    public float minX = -2.6f, maxX = 2.6f, minY = -5.6f;
    private bool _outOfBounds;
    void Update()
    {
        CheckBounds();
    }

    void CheckBounds()
    {
        Vector2 temp = transform.position;
        if (temp.x > maxX)
        {
            temp.x = maxX;
        }

        if (temp.x < minX)
        {
            temp.x = minX;
        }

        transform.position = temp;
        if (temp.y <= minY)
        {
            if (!_outOfBounds)
            {
                _outOfBounds = true;
                SoundManager.instance.DeathSound();
                GameManager.instance.RestartGame();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag.Equals("TopSpike"))
        {
            Destroy(gameObject);
            SoundManager.instance.DeathSound();
            GameManager.instance.RestartGame();
        }
    }
}
