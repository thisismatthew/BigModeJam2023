using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmotionDispenser : MonoBehaviour
{
    // When the player comes up they can trigger a minigame
    // When the minigame completes they get an emotion orb - that geets dumped out

    private bool active = false;
    public GameObject Minigame;
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
        if (Minigame.activeInHierarchy) return;
        
        
        if (Input.GetKeyDown(KeyCode.E) && active)
        {
            Minigame.gameObject.SetActive(true); 
        }
        
    }

    public void DispenseEmotion()
    {
        Instantiate(EmotionRewardPrefab, EmotionRewardSpawnPosition);
    }
    
    
    public void MinigameResult(bool success)
    {
        if (success)
        {
            DispenseEmotion();
        }
        Minigame.gameObject.SetActive(false);
    }
}
