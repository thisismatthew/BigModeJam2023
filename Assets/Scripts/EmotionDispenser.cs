using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmotionDispenser : MonoBehaviour
{
    // When the player comes up they can trigger a minigame
    // When the minigame completes they get an emotion orb - that geets dumped out

    private bool active = false;
    public EmotionMinigame Minigame;
    public bool MinigameActive = false;
    public GameObject EmotionRewardPrefab;
    public Transform EmotionRewardSpawnPosition;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) active = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) active = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Minigame.isActiveAndEnabled) return;
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Minigame.gameObject.SetActive(true);
            Minigame.StartMinigame();
        }
        
    }

    public void DispenseEmotion()
    {
        Instantiate(EmotionRewardPrefab, EmotionRewardSpawnPosition);
    }
}
