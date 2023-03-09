using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    public Animator animator;

    public float speed = 10f;
    public float startingHealth = 100f; // The player's starting health
    public float currentHealth; // The player's current health

    public void Start()
    {   

        animator = GetComponent<Animator>();
         currentHealth = startingHealth;

    } 
        public void Update()
        {
            bool isWalking = animator.GetBool("isWalking");
            bool forwardPressed = Input.GetKey(KeyCode.UpArrow);
            bool isBackward = animator.GetBool("isBackwards");
            bool backwardPressed = Input.GetKey(KeyCode.DownArrow);
            bool isRunning = animator.GetBool("isRunning");
            bool runningPressed = Input.GetKey(KeyCode.X);
            bool isPunching = animator.GetBool("isPunching");
            bool punchingPressed = Input.GetKey(KeyCode.M);

        
        transform.position += transform.forward * speed * Time.deltaTime;
 
        if (Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            transform.Rotate(0.0f, -45.0f, 0.0f);
        }

      
        if (Input.GetKeyDown(KeyCode.RightArrow)) 
        {
            transform.Rotate(0.0f, 45.0f, 0.0f);
        }
        
        //if player pressed forward key (or up arrow)
        if(forwardPressed)
        {
            animator.SetBool("isWalking", true);
        }
        if(!forwardPressed)
        {
            animator.SetBool("isWalking", false);
        }

        //if player pressed backward key (or down arrow)
        if(backwardPressed)
        {
            animator.SetBool("isBackwards", true);
        }
        if(!backwardPressed)
        {
            animator.SetBool("isBackwards", false);
        }

        if(punchingPressed)
        {
            animator.SetBool("isPunching", true);
        }
        if(!punchingPressed)
        {
            animator.SetBool("isPunching", false);
        }

        //if player pressed the x key 
        if(runningPressed && forwardPressed)
        {
            animator.SetBool("isRunning", true);
        }
        if(!runningPressed)
        {
            animator.SetBool("isRunning", false);
        }

    }

    public void TakeDamage(float damageAmount)
    {
        // Reduce the player's health by the damage amount
        currentHealth -= damageAmount;

        // Check if the player's health has reached zero or below
        if (currentHealth <= 0f)
        {
            // If the player has died, deactivate the player object and show a game over message
            gameObject.SetActive(false);
            Debug.Log("Game Over");
        }
    }

}


