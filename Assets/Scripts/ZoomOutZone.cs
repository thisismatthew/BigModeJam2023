using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class ZoomOutZone : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera WideCam;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            WideCam.Priority = 100;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            WideCam.Priority = -1;
        }
    }
}
