using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterState
{
    idle,
    walking,
}

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public Animator BrainRigAnimator;
    public GameObject VisualsFlipper;
    public CharacterState CurrentState = CharacterState.idle;
    private CharacterState newState = CharacterState.idle;
    private bool facingRight = false;

    private void Start()
    {
        //nm = FindObjectOfType<NotebookManager>();
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }

    private void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement == Vector2.zero)
        {
            newState = CharacterState.idle;
        }
        else
        {
            Debug.Log(movement.x);
            if (movement.x > 0) facingRight = true;
            if (movement.x < 0) facingRight = false;
            newState = CharacterState.walking;
        }
    }

    private void FixedUpdate()
    {
        UpdateAnimation();
        if (CurrentState == CharacterState.walking)
        {
            rb.MovePosition(rb.position + movement * moveSpeed);
        }
    }

    private void UpdateAnimation()
    {
        if (newState != CurrentState)
        {
            CurrentState = newState;
            switch (CurrentState)
            {
                case CharacterState.idle:
                    BrainRigAnimator.Play("brain_idle");
                    break;
                case CharacterState.walking:
                    BrainRigAnimator.Play("brain_walk");
                    break;
            }

            Vector3 flipscale = Vector3.one;
            if (facingRight)
            {
               flipscale.x  = -1;
            }
            else
            {
                flipscale.x = 1;
            }
            VisualsFlipper.transform.localScale = flipscale;
        }
    }
}
