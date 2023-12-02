using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmotionMinigame : MonoBehaviour
{
    public bool MinigameSuccessState = false;

    public void StartMinigame()
    {
        MinigameSuccessState = false;
    }
    
    public void EndMinigame(bool result)
    {
        MinigameSuccessState = result;
        this.gameObject.SetActive(false);
    }
}
