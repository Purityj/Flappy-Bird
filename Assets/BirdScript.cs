using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    // A reference to the RigidBody2D component
    public Rigidbody2D myRigidBody;
    
    // var for the flab speed/strength to allow us to change 
    // it's value when playing the game
    public float flapStrength;

    // reference LogicScript
    public LogicScript logic;

    // check if bird is alive
    public bool birdIsAlive = true;

    public AudioSource jumpSoundEffect;

    public AudioSource deathSoundEffect;

    // var for upward movement
    public float upwardSpeed;
    // var for backward movement
    public float backwardSpeed;
    // var for downward movement
    public float downwardSpeed;
    // var for forward movement
    public float forwardSpeed;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();  
    }

    // Update is called once per frame
    void Update()
    {
        // in each frame, space bar key press down will be checked
        // if true, and the bird is still alive then the bird will fly upwards
        // if the bird is dead, then it won't flap
        if(Input.GetKeyDown(KeyCode.Space) && birdIsAlive){
            jumpSoundEffect.Play();
            myRigidBody.velocity = Vector2.up * flapStrength;
        }
        // move forward when the right arrow key is pressed
        if(Input.GetKey(KeyCode.RightArrow) && birdIsAlive){
            myRigidBody.velocity = new Vector2(forwardSpeed, myRigidBody.velocity.y);
        }
        // move backward when the LeftArrow key is pressed
        if (Input.GetKey(KeyCode.LeftArrow) && birdIsAlive){
            myRigidBody.velocity = new Vector2(-backwardSpeed, myRigidBody.velocity.y);
        }
        // move upward when UpArrow is pressed 
        if(Input.GetKey(KeyCode.UpArrow) && birdIsAlive){
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, upwardSpeed);
        }
        // move downward when the DownArrow key is pressed
        if(Input.GetKey(KeyCode.DownArrow) && birdIsAlive){
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, -downwardSpeed);
        }
        // if the bird goes off the screen, call gameOver function and stop the bird from flapping
        if(transform.position.y > 18 || transform.position.y < -18){
            logic.gameOver();
            birdIsAlive = false;
        } 
    }

    private void OnCollisionEnter2D(Collision2D collsion) 
    {
        deathSoundEffect.Play();
        logic.gameOver();
        birdIsAlive = false;
    }
}

