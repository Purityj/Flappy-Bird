using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The purpose of this script is to spawn new versions of pipe prefab every few seconds
// since the pipe already has a code for the pipes to move left, the pipe will automatically 
// move left as soon as it's spawns
public class PipeSpawnerScript : MonoBehaviour
{
    // a reference to the pipe prefab
    public GameObject pipe;
    // spawn rate is the time between each spawn
    public float spawnRate = 20;
    // counter
    private float timer = 0;
    // to vary the height of the pipes being spawned so that they are not of the smae height
    public float heightOffset = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        // to spawn a pipe at the start of the game
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            //if the timer is less than the spawn rate then increment the timer
            timer += Time.deltaTime;
        }else{
            // if not then spawn a new pipe then start the timer again
            // i.e spawn a pipe each time the timer maxes out
            spawnPipe();
             timer = 0;
        }
        
    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        // use the Instantiate method to spawn new GameObjects
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
