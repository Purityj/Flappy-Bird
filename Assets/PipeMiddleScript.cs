using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    // reference LogicScript.cs
    public LogicScript logic;
    // Start is called before the first frame update
    void Start()
    {
        // as soon as the 1st pipe spawns:
        // find gameobject with tag 'Logic' then find a component called LogicScript
        // after finding it, it will put it in our reference slot i.e logic
        // this is the same as dragging and dropping the component in the editor
        // GameObject logicObject = GameObject.FindGameObjectWithTag("Logic");

        // if (logicObject != null)
        // {
        //     logic = logicObject.GetComponent<LogicScript>();
        // }else{
        //     Debug.LogError("Cannot fidn the object with tag 'Logic' or it doesnt have LogicScript attached.");
        // }
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // anything in this method will run when the bird(object) hits the trigger
    // there are also OnTriggerExit and OnTriggerStay methods
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // check if the collision is with the gameobject of Bird's layer 
        // add the addScore() method from LogicScript.cs to enable player score to increase 
        // and also be displayed in the UI
        if(collision.gameObject.layer == 3)
        {
            logic.addScore(1);
        }
        
        
    }
}
