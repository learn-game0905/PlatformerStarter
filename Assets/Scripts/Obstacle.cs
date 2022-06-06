using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private Slider obstacleHealthBar;
    [SerializeField] private Animator anim;
    private Vector3 moveLogic;
    private float speed = 5;
    private float health;
    
    void Start()
    {
        moveLogic = Vector3.left * speed;
        health = obstacleHealthBar.value;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveLogic * Time.deltaTime);
        
        if (obstacleHealthBar.value <= 0)
        {
            Destroy(gameObject);
            obstacleHealthBar.transform.DOScale(new Vector3(0f, 0f, 0f) , 0.3f);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("trai"))
        {
            if (transform.localScale.x > 0)
            {
                gameObject.transform.localScale = new Vector3(
                    gameObject.transform.localScale.x * -1,
                    gameObject.transform.localScale.y,
                    gameObject.transform.localScale.z
                );
            }
            moveLogic = Vector3.right * speed;
        }
        
        if (col.CompareTag("phai"))
        {
            if (transform.localScale.x < 0)
            {
                gameObject.transform.localScale = new Vector3(
                    gameObject.transform.localScale.x * -1,
                    gameObject.transform.localScale.y,
                    gameObject.transform.localScale.z
                );
            }
            moveLogic = Vector3.left * speed;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
        {
            if (healthBar.value <= 0)
            {

            }

        }
    }
}
