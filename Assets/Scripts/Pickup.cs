using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject currentlyHeld;
    private List<Collider2D> potentialItemsToHold = new List<Collider2D>();

    private float dropTimer = 0f;

    private float timeToWaitBeforeYouCanDropItem = .2f;
    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pickup")) potentialItemsToHold.Add(other);

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Pickup"))
        {
            bool shouldRemove = false;
            foreach (var item in potentialItemsToHold)
            {
                if (other == item)
                {
                    shouldRemove = true;
                }
            }

            if (shouldRemove) potentialItemsToHold.Remove(other);
        }
    }

    private void PickupOther(Collider2D other)
    {
        Debug.Log("Pickup on: " + other.name);
        if (currentlyHeld != null) return;
        other.transform.parent = this.transform;
        var rb = other.GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        other.transform.DOMove(this.transform.position, .1f);
        other.GetComponent<Collider2D>().enabled = false;
        /*var spr = other.GetComponent<SpriteRenderer>();
            spr.sortingLayerID = SortingLayer.NameToID("Player");*/
        currentlyHeld = other.gameObject;
    }

    private void Update()
    {
        if (currentlyHeld != null)
        {
            dropTimer += Time.deltaTime;
        }

        if (currentlyHeld == null && potentialItemsToHold.Count>0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                PickupOther(potentialItemsToHold[0]);
        }
        
        if (dropTimer>timeToWaitBeforeYouCanDropItem && Input.GetKeyDown(KeyCode.Space))
        {
            DropOther();
        }
    }

    private void DropOther()
    {
        dropTimer = 0;
        Debug.Log("Drop");
        var spr = currentlyHeld.GetComponent<SpriteRenderer>();
        spr.sortingLayerID = SortingLayer.NameToID("Default");
        currentlyHeld.GetComponent<Rigidbody2D>().isKinematic = false;
        currentlyHeld.GetComponent<Collider2D>().enabled = true;
        currentlyHeld.transform.parent = null;
        currentlyHeld = null;
    }
}
