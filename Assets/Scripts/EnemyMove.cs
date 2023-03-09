using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 

public class EnemyMove : MonoBehaviour
{
   public Transform target; // The target object to follow
    public float attackDistance = 1.5f; // The distance at which the enemy will attack the player
    public float movementSpeed = 3.5f; // The speed at which the enemy will move towards the player
    public Animator animator; // The animator component for the enemy
 public float damage = 10f; // Amount of damage dealt to the player
    private Vector3 initialPosition; // The initial position of the enemy
    private bool isAttacking; // Whether the enemy is currently attacking the player
private PlayerMovement playerHealth; // Reference to the player's health component
public float punchRate = 2f;
public GameObject player;
private bool isPunching; // Whether the enemy is currently punching
 private bool isCollidingWithPlayer; // Whether the enemy is currently colliding with the player
private float nextPunchTime; // Time of the next allowed punch
    private void Awake()
    {
        // Find the player's health component and store a reference to it
        playerHealth = FindObjectOfType<PlayerMovement>();
    }
    
    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        
            if (target != null)
            {
                // Calculate the direction to the target
                Vector3 direction = target.position - transform.position;
                direction.y = 0f;
                direction.Normalize();

                // Move the enemy towards the target
                transform.position += direction * movementSpeed * Time.deltaTime;

                // Rotate the enemy towards the target
                transform.rotation = Quaternion.LookRotation(direction);

                

                if (isPunching && !isCollidingWithPlayer)
                {
                    Debug.Log("YES");
                isPunching = false;
                }
                    
        animator.SetBool("isPunching", isPunching);
            }
    }
    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject==player)
        {
            isPunching = true;
            if (Time.time >= nextPunchTime)
                {
                    animator.SetBool("isRunning", false);
                    
                    playerHealth.TakeDamage(damage);
                    nextPunchTime = Time.time + 1f / punchRate;
                }
        }

       
}
private void OnCollisionExit(Collision collision)
     {
        if(collision.gameObject==player){
            isCollidingWithPlayer = false;
            isPunching = false;
        animator.SetBool("isRunning", true);
                    
        }
     } 
}