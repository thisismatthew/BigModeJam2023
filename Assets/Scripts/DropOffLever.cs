using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOffLever : MonoBehaviour
{
    private bool playerNearLever = false;
    private bool flipped = false;
    private Animator anim;
    [SerializeField] private EmotionChecker DropOffPointCollider;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearLever = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearLever = false;
        }
    }

    private void Update()
    {
        if (playerNearLever  && Input.GetKeyDown(KeyCode.Space))
        {
            if (!flipped)
            {
                anim.Play("lever_flip_on");
                flipped = true;
                DropOffPointCollider.ProcessEmotions();
            }
            else
            {
                anim.Play("lever_flip_off");
                flipped = false;
            }
        }
    }
    
    
}
