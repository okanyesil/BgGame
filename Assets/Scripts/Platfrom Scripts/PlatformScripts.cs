using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScripts : MonoBehaviour
{
    public float moveSpeed = 2f;

    public float boundY = 6f;

    public bool movingPlatformLeft, movingPlatformRight, isBreakable, isSpike, isPlatform;

    private Animator _animator;

    private void Awake()
    {
        if (isBreakable)
        {
            _animator = GetComponent<Animator>();
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 temp = transform.position;
        temp.y += moveSpeed * Time.deltaTime;
        transform.position = temp;

        if (temp.y >= boundY)
        {
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    void BreakableDeactivate()
    {
        Invoke("DeactivateGameObject", 0.3f);
    }

    void DeactivateGameObject()
    {
        SoundManager.instance.IceBreakSound();
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag.Equals("Player"))
        {
            if (isSpike)
            {
                target.transform.position = new Vector2(1000f,1000f);
                SoundManager.instance.GameOverSound();
                GameManager.instance.RestartGame();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag.Equals("Player"))
        {
            if (isBreakable)
            {
                SoundManager.instance.LandSound();
                _animator.Play("Break");
            }

            if (isPlatform)
            {
                SoundManager.instance.LandSound();
            }
        }
    }

    private void OnCollisionStay2D(Collision2D target)
    {
        if (target.gameObject.tag.Equals("Player"))
        {
            if (movingPlatformLeft)
            {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(-1f);
            }
            if (movingPlatformRight)
            {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(+1f);
            }
        }
    }
}
