using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmotionChecker : MonoBehaviour
{
    private List<GameObject> Emotions = new List<GameObject>();
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other)
    {
        Emotions.Add(other.gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Emotions.Remove(other.gameObject);
    }

    public void ProcessEmotions()
    {
        List<GameObject> buffer = new List<GameObject>();
        foreach (var e in Emotions)
        {
            buffer.Add(e);
        }
        //TODO hook up to dialogue system and timer
        Emotions.Clear();
        foreach (var b in buffer)
        {
            Destroy(b);
        }
    }
}
